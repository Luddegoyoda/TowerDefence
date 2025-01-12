using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class Healthbar
    {
        float maxHealth;
        float healthShare = 1;
        Rectangle redFill, hitbox;

        public Healthbar(int maxHealth)
        {
            this.maxHealth = maxHealth;
            redFill = new Rectangle(28, 123, 40, 16);
            hitbox = new Rectangle(0, 0, 40, 16);
        }

        public void Update(GameTime gameTime, Vector2 position )
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
            
        }
        
        public void TakeDamage(float health)
        {
            healthShare = health / maxHealth;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AssetManager.allTextures[2], new Rectangle(hitbox.X,hitbox.Y,(int)MathF.Ceiling(hitbox.Width * healthShare),hitbox.Height), redFill,Color.White);
        }

    }
}
