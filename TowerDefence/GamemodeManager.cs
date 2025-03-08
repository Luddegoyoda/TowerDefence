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
        public static int lives = 30;
        public static int resources = 500;
        public static int waveNumber = 1;

        
        public GamemodeManager()
        {

        }

        public void Update()
        {
            if (lives <= 0)
            {
                Game1.gameState = Game1.GAMESTATE.LOST;
            }
        }

        public void Reset()
        {
            lives = 30;
            resources = 500;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            switch (Game1.gameState)
            {
                case Game1.GAMESTATE.MENU:
                    
                    spriteBatch.DrawString(AssetManager.font, "Defence of the computer", new Vector2(400, 0), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(AssetManager.font, "Press [M] to play", new Vector2(400, 30), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(AssetManager.font, "Press [E] to enter the map editor", new Vector2(400, 60), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);

                    
                    break;
                case Game1.GAMESTATE.PLAYING:
                    spriteBatch.DrawString(AssetManager.font, "Lives: " + lives, new Vector2(300, 0), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(AssetManager.font, "Resources: " + resources, new Vector2(300, 30), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);


                    spriteBatch.DrawString(AssetManager.font, "Time to next wave: " + EnemyManager.timeToNextWave + " / 15000", new Vector2(400, 60), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(AssetManager.font, "Wave number: "+ waveNumber, new Vector2(400, 100), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);

                    spriteBatch.DrawString(AssetManager.font, "Press [1] to hire Antivirus. Cost 500", new Vector2(800, 0), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(AssetManager.font, "Click on Antivirus to upgrade", new Vector2(800, 50), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(AssetManager.font, "Press [C] to close upgrade menu", new Vector2(800, 100), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                    break;
                case Game1.GAMESTATE.LOST:
                    spriteBatch.DrawString(AssetManager.font, "The computer has been infected by the virus!", new Vector2(500, 200), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(AssetManager.font, "Press [M] to play again!", new Vector2(500, 220), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                    break;
                case Game1.GAMESTATE.EDITOR:
                    spriteBatch.DrawString(AssetManager.font, "Press [K] to exit the map editor", new Vector2(500, 100), Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                    break;
            }
            

            
        }
    }
}
