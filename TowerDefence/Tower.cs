using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public class Tower : GameObject
    {
        ParticleEmitter particles;
        public Texture2D texture, circleTexture;
        public Vector2 position;
        public Rectangle hitbox, sourceRect;
        public int range, damage, cost;
        public float attackSpeed;
        int timeToNextAttack;
        public int damageUpgrade = 0, attackSpeedUpgrade = 0, SlowingUpgrade = 0, rangeUpgrade = 0;
        public bool showingDetail, slowing, areaOfEffect;
        Color color;
        public List<Enemy> enemiesInRange;
        GraphicsDevice graphicsDevice;

        public Tower(GraphicsDevice graphicsDevice, Texture2D texture,Vector2 position,Rectangle hitbox, int range, int damage, float attackSpeed, int timeToNextAttack, int cost, Color color) : base(texture,position,hitbox)
        {
            this.texture = texture;
            this.position = position;
            this.hitbox = hitbox;
            this.range = range;
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.timeToNextAttack = timeToNextAttack;
            this.cost = cost;
            this.graphicsDevice= graphicsDevice;

            this.color = color;

            particles = new ParticleEmitter();
            enemiesInRange = new List<Enemy>();
            showingDetail = false;
            sourceRect = new Rectangle(0, 0, 40,40);

            circleTexture = CreateOutlinedCircleTexture(range, Color.White, 1);
        }

        public override void Update(GameTime gameTime)
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;

            particles.Update(gameTime, position);

            timeToNextAttack += gameTime.ElapsedGameTime.Milliseconds;
            foreach (Enemy enemy in enemiesInRange)
            {
                if (timeToNextAttack > attackSpeed && enemy != null && enemy.health > 0)
                {
                    enemy.TakeDamage(damage * (damageUpgrade + 1));
                    if (SlowingUpgrade > 0)
                    {
                        float slowValue = SlowingUpgrade / 10f;
                        if (enemy.speed - slowValue >= 0.1)
                        {
                            enemy.speed = enemy.speed - slowValue;
                        }
                        else
                        {
                            enemy.speed = 0.1f;
                        }
                        
                    }
                    timeToNextAttack= 0;
                    SoundManager.PlayEffect(SoundManager.allSoundEffects[0]);
                    particles.DeployParticles();

                    break;
                }
            }
            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                if (enemiesInRange[i].health <= 0)
                {
                    enemiesInRange.RemoveAt(i);
                }
            }
        }

        public void UpdateRangeIndicator() 
        {
            circleTexture = CreateOutlinedCircleTexture(range, Color.White, 1);
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


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, sourceRect, color);
            particles.Draw(spriteBatch);
        }

        
    }
}
