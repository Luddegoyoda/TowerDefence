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
        int maxHealth;
        int curerentHealth;
        Rectangle redFill, outline;

        public Healthbar(int maxHealth)
        {
            this.maxHealth = maxHealth;
            redFill = new Rectangle(28, 123, 40, 16);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AssetManager.allTextures[2],new Rectangle(0,0,40,16),redFill,Color.White);
        }

    }
}
