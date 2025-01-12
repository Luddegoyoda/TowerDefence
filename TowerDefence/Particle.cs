using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class Particle : GameObject
    {
        Texture2D texture;
        Vector2 position, direction; 
        Rectangle hitbox, sourceRect;
        float time = 0, timeToLive, speed;
        Color color;
        public bool isAlive;
        public Particle(Texture2D texture, Vector2 position, Rectangle hitbox, float timeToLive, Vector2 direction, float speed, Color color) : base(texture, position, hitbox)
        {
            this.texture = texture;
            this.position = position;
            this.hitbox = hitbox;
            this.timeToLive = timeToLive;
            this.direction = direction;
            this.speed = speed;
            this.color = color;
            isAlive= true;
            sourceRect= new Rectangle(1050, 654, 4,4);
        }

        public override void Update(GameTime gameTime)
        {
            time += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
            if (time < timeToLive)
            {
                if (direction.X > 0)
                {
                    position.X += speed;
                }
                if (direction.X < 0)
                {
                    position.X -= speed;
                }
                if (direction.Y > 0)
                {
                    position.Y += speed;
                }
                if (direction.Y < 0)
                {
                    position.Y -= speed;
                }
                color.B++;
            }
            else
            {
                isAlive = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, sourceRect, color);
        }

        
    }
}
