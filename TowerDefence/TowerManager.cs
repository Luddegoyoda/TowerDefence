using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public class TowerManager
    {
        public List<Tower> towers = new List<Tower>();
        Texture2D circleTexture;
        GraphicsDevice graphicsDevice;
        public TowerManager(GraphicsDevice graphicsDevice) 
        {
            this.graphicsDevice = graphicsDevice;
        }

        public void Update(GameTime gameTime)
        {
            foreach (Tower tower in towers)
            {
                tower.Update(gameTime);
            }
        }


        Texture2D CreateOutlinedCircleTexture(int radius, Color color, int thickness)
        {
            int diameter = radius * 2;
            Texture2D texture = new Texture2D(graphicsDevice, diameter, diameter);
            Color[] colorData = new Color[diameter * diameter];


            // Draw the circle outline by setting pixels only along the circle's edge
            for (int y = 0; y < diameter; y++)
            {
                for (int x = 0; x < diameter; x++)
                {
                    int dx = x - radius;
                    int dy = y - radius;
                    float distanceSquared = dx * dx + dy * dy;
                    float outerRadiusSquared = radius * radius;
                    float innerRadiusSquared = (radius - thickness) * (radius - thickness);

                    // Check if the pixel is within the outline thickness
                    if (distanceSquared <= outerRadiusSquared && distanceSquared >= innerRadiusSquared)
                    {
                        colorData[x + y * diameter] = color;
                    }
                    else
                    {
                        colorData[x + y * diameter] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;

        }

        public bool CanPlaceTower(Tower newTower)
        {
            Color[] pixels = new Color[newTower.texture.Width * newTower.texture.Height];
            Color[] pixels2 = new Color[newTower.texture.Width * newTower.texture.Height];
            newTower.texture.GetData<Color>(pixels2);
            Game1.renderTarget.GetData(0, newTower.hitbox, pixels, 0, pixels.Length);
            for (int i = 0; i < pixels.Length; ++i)
            {
                if (pixels[i].A > 0.0f && pixels2[i].A > 0.0f)
                    return false;
            }
            return true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tower tower in towers)
            {
                circleTexture = CreateOutlinedCircleTexture(tower.range, Color.White, 1);
                spriteBatch.Draw(circleTexture, new Vector2(tower.position.X + 16, tower.position.Y + 16), null, Color.White, 0f, new Vector2(tower.range, tower.range), 1f, SpriteEffects.None, 0f);
                tower.Draw(spriteBatch);
            }
            
        }
    }
}
