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
        int range, damage;
        float attackSpeed;
        int timeToNextAttack;

        public Tower(Texture2D texture,Vector2 position,Rectangle hitbox, int range, int damage, float attackSpeed, int timeToNextAttack) : base(texture,position,hitbox)
        {
            this.texture = texture;
            this.position = position;
            this.hitbox = hitbox;
            this.range = range;
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.timeToNextAttack = timeToNextAttack;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
