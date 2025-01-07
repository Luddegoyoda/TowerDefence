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
        float attackSpeed;
        int timeToNextAttack;
        public bool showingDetail;

        public List<Enemy> enemiesInRange;

        public Tower(Texture2D texture,Vector2 position,Rectangle hitbox, int range, int damage, float attackSpeed, int timeToNextAttack) : base(texture,position,hitbox)
        {
            this.texture = texture;
            this.position = position;
            this.hitbox = hitbox;
            this.range = range;
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.timeToNextAttack = timeToNextAttack;
            enemiesInRange= new List<Enemy>();
            showingDetail = false;
            cost = 500;
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
                    enemy.TakeDamage(damage);
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
