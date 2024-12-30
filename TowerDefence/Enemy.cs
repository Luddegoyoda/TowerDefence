using CatmullRom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefence
{
    public class Enemy
    {
        public Rectangle hitBox;
        public int health;
        public float speed = 0.5f, position = 0;
        CatmullRomPath path;

        public Enemy(CatmullRomPath path) 
        {
            this.path = path;
            health = 1;
        }

        public void Update(GameTime gameTime)
        {
            position += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (position < 1 & position > 0)
            {
                Vector2 vec = path.EvaluateAt(position);
                hitBox.X = (int)vec.X;
                hitBox.Y = (int)vec.Y;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            path.DrawMovingObject(position, spriteBatch, AssetManager.allTextures[1]);

        }
    }

    
}
