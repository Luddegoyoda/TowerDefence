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

        public static RenderTarget2D renderTarget;
        public float scale = 0.4444f;

        GamemodeManager gamemodeManager;
        EnemyManager enemyManager;

        Tower tower;

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

            _graphics.PreferredBackBufferHeight = 1280;
            _graphics.PreferredBackBufferWidth = 720;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            renderTarget = new RenderTarget2D(GraphicsDevice,1920 , 1080);

            AssetManager.LoadAllTextures(Content);
            enemyManager.path = gamemodeManager.GetPath();

            tower = new Tower(AssetManager.allTextures[1], new Vector2(600,600), new Rectangle(1, 1, 16, 16), 0, 0, 0, 0);

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
            scale = 1f / (1080f / GraphicsDevice.Viewport.Height);

            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.Green);

            _spriteBatch.Begin();
            tower.Draw(_spriteBatch);
            gamemodeManager.Draw(_spriteBatch);

            
            
            enemyManager.Draw(_spriteBatch);

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Green);

            _spriteBatch.Begin();
            _spriteBatch.Draw(renderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}