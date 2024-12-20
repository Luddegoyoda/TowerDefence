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
        GraphicsDevice graphicsDevice;
        CatmullRomPath enemyPath;

        bool shouldGenerateMap;

        public GamemodeManager(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            shouldGenerateMap = true;
        }

        public void Update()
        {
            if (shouldGenerateMap)
            {
                CreatePath();
                shouldGenerateMap= false;
            }
        }

        public void CreatePath()
        {
            enemyPath = new CatmullRomPath(graphicsDevice, 0.5f);
            enemyPath.Clear();

            enemyPath.AddPoint(new Vector2(0, 0));
            enemyPath.AddPoint(new Vector2(300, 100));
            enemyPath.AddPoint(new Vector2(400, 200));
            enemyPath.AddPoint(new Vector2(600, 350));
            enemyPath.AddPoint(new Vector2(800, 600));

            enemyPath.DrawFillSetup(graphicsDevice, 30, 5, 26);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemyPath.DrawFill(graphicsDevice, AssetManager.allTextures[0]);
        }
    }
}
