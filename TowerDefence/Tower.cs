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
        public Texture2D texture;
        public Vector2 position;
        public Rectangle hitbox;
        public int range, damage, cost;
        public float attackSpeed;
        int timeToNextAttack;
        public int damageUpgrade = 0, attackSpeedUpgrade = 0, SlowingUpgrade = 0, AOEUpgrade = 0;
        public bool showingDetail, slowing, areaOfEffect;

        public List<Enemy> enemiesInRange;

        public Tower(Texture2D texture,Vector2 position,Rectangle hitbox, int range, int damage, float attackSpeed, int timeToNextAttack, int cost) : base(texture,position,hitbox)
        {
            this.texture = texture;
            this.position = position;
            this.hitbox = hitbox;
            this.range = range;
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.timeToNextAttack = timeToNextAttack;
            this.cost = cost;

            enemiesInRange = new List<Enemy>();
            showingDetail = false;
        }

        public override void Update(GameTime gameTime)
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;

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



        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        
    }
}
