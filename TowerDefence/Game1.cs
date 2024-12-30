using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Spline;
using CatmullRom;

namespace TowerDefence
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        GamemodeManager gamemodeManager;
        EnemyManager enemyManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            gamemodeManager = new GamemodeManager(GraphicsDevice);
            enemyManager = new EnemyManager();
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            AssetManager.LoadAllTextures(Content);
            enemyManager.path = gamemodeManager.GetPath();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gamemodeManager.Update();
            enemyManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            gamemodeManager.Draw(_spriteBatch);
            _spriteBatch.Begin();
            _spriteBatch.End();
            enemyManager.Draw(_spriteBatch);
            



            base.Draw(gameTime);
        }
    }
}