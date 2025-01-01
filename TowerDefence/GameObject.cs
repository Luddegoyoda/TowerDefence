using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public abstract class GameObject
    {
        Texture2D texture;
        Vector2 position;
        Rectangle hitbox;
        public GameObject(Texture2D texture, Vector2 position, Rectangle hitbox)
        {
            this.texture = texture;
            this.position = position;
            this.hitbox = hitbox;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
