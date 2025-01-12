using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class ParticleEmitter 
    {
        List<Particle> particles;
        Vector2 startPosition;
        public ParticleEmitter()
        {
            particles= new List<Particle>();
            
        }

        public void DeployParticles()
        {
            particles.Add(new Particle(AssetManager.allTextures[0], new Vector2(startPosition.X + 15,startPosition.Y + 15), new Rectangle(0, 0, 8, 8), 100, new Vector2(1, 1), 3, Color.Pink));
            particles.Add(new Particle(AssetManager.allTextures[0], new Vector2(startPosition.X + 15, startPosition.Y + 15), new Rectangle(0, 0, 8, 8), 100, new Vector2(-1, 1), 3, Color.LightBlue));
            particles.Add(new Particle(AssetManager.allTextures[0], new Vector2(startPosition.X + 15, startPosition.Y + 15), new Rectangle(0, 0, 8, 8), 100, new Vector2(1, -1), 3, Color.LightBlue));
            particles.Add(new Particle(AssetManager.allTextures[0], new Vector2(startPosition.X + 15, startPosition.Y + 15), new Rectangle(0, 0, 8, 8), 100, new Vector2(-1, -1), 3, Color.LightBlue));
        }

        public void Update(GameTime gameTime, Vector2 startPosition)
        {
            this.startPosition= startPosition;

            if (particles.Count != 0)
            {
                foreach (Particle particle in particles)
                {
                    if (particle.isAlive)
                        particle.Update(gameTime);
                }
            }
            for (int i = 0; i < particles.Count; i++)
            {
                if (!particles[i].isAlive)
                {
                    particles.RemoveAt(i);
                }
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (particles.Count != 0)
            {
                foreach (Particle particle in particles)
                {
                    if (particle.isAlive)
                        particle.Draw(spriteBatch);
                }
            }
        }

         
    }
}
