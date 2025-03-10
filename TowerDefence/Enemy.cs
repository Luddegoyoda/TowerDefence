﻿using CatmullRom;
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
        public int health, pointGain;
        public float speed = 0.5f, position = 0;
        CatmullRomPath path;
        Healthbar healthbar;

        public Enemy(CatmullRomPath path, int health, float speed, int pointGain) 
        {
            this.path = path;
            this.health = health;
            this.speed = speed;
            this.pointGain = pointGain;
            healthbar = new Healthbar(health);
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
            healthbar.Update(gameTime,new Vector2(hitBox.X,hitBox.Y - 40));
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            healthbar.TakeDamage(health);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.End();
            path.DrawMovingObject(position, spriteBatch, AssetManager.allTextures[1]);
            spriteBatch.Begin();
            healthbar.Draw(spriteBatch);
        }
    }

    
}
