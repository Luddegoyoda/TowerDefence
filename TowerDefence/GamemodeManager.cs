using CatmullRom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public class GamemodeManager
    {

        public static int lives = 10;
        public static int resources = 500;

        bool shouldGenerateMap;

        public GamemodeManager()
        {

            shouldGenerateMap = true;
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            

            spriteBatch.DrawString(AssetManager.font, "Lives: " + lives, new Vector2(0, 0), Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
            

            spriteBatch.DrawString(AssetManager.font, "Resources: " + resources, new Vector2(0, 20), Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);

            
        }
    }
}
