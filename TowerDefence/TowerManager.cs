using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
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
        static UpgradeView upgradeView;
        public TowerManager(GraphicsDevice graphicsDevice) 
        {
            this.graphicsDevice = graphicsDevice;
            
        }

        public void Reset()
        {
            towers.Clear();
        }

        public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            var mousePoint = new Point(mouseState.X, mouseState.Y);
            foreach (Tower tower in towers)
            {
                tower.Update(gameTime);
                if (tower.hitbox.Contains(mousePoint) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    foreach (Tower otherTowers in towers)
                    {
                        otherTowers.showingDetail = false;
                        
                    }
                    tower.showingDetail = true;
                    UpgradeView.ShowTowerInformation(tower);
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                foreach (Tower tower in towers)
                {
                    tower.showingDetail = false;
                    UpgradeView.HideTowerInformation();
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                if (GamemodeManager.resources >= towers[0].cost)
                {
                    Tower newTower = new Tower(AssetManager.allTextures[3], new Vector2(mousePoint.X, mousePoint.Y), new Rectangle(mousePoint.X, mousePoint.Y, 40, 40), 250, 25, 500, 0, 500,Color.Red);
                    if (CanPlaceTower(newTower))
                    {
                        towers.Add(newTower);
                        GamemodeManager.resources -= towers[0].cost;
                    }

                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                if (GamemodeManager.resources >= towers[0].cost)
                {
                    Tower newTower = new Tower(AssetManager.allTextures[3], new Vector2(mousePoint.X, mousePoint.Y), new Rectangle(mousePoint.X, mousePoint.Y, 40, 40), 150, 40, 700, 0, 500, Color.DarkBlue);
                    if (CanPlaceTower(newTower))
                    {
                        towers.Add(newTower);
                        GamemodeManager.resources -= towers[0].cost;
                    }

                }
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
            try
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
            catch
            {
                return true;
            }
            
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tower tower in towers)
            {
                if (tower.showingDetail)
                {
                    circleTexture = CreateOutlinedCircleTexture(tower.range, Color.White, 1);
                    spriteBatch.Draw(circleTexture, new Vector2(tower.position.X + 15, tower.position.Y + 15), null, Color.White, 0f, new Vector2(tower.range, tower.range), 1f, SpriteEffects.None, 0f);
                }
                
                tower.Draw(spriteBatch);
            }
            
        }
    }
}
