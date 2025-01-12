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
        TowerManager towerManager;

        CatmullRomPath enemyPath;

        public enum GAMESTATE { MENU, PLAYING, LOST };
        public static GAMESTATE gameState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            gamemodeManager = new GamemodeManager();
            enemyManager = new EnemyManager();
            towerManager = new TowerManager(GraphicsDevice);

            this.Components.Add(new UpgradeView(this));

            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            renderTarget = new RenderTarget2D(GraphicsDevice, 1280,720 );

            AssetManager.LoadAllTextures(Content);


            enemyManager.path = CreatePath();

            SoundManager.LoadAllSounds(Content);

            // TODO: use this.Content to load your game content here
        }

        public CatmullRomPath CreatePath()
        {
            enemyPath = new CatmullRomPath(GraphicsDevice, 0.5f);
            enemyPath.Clear();

            enemyPath.AddPoint(new Vector2(0, 0));
            enemyPath.AddPoint(new Vector2(300, 100));
            enemyPath.AddPoint(new Vector2(400, 200));
            enemyPath.AddPoint(new Vector2(600, 350));
            enemyPath.AddPoint(new Vector2(800, 600));
            enemyPath.AddPoint(new Vector2(990, 730));

            enemyPath.DrawFillSetup(GraphicsDevice, 30, 5, 26);

            return enemyPath;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gamemodeManager.Update();
            switch (gameState)
            {
                case Game1.GAMESTATE.MENU:
                    if (Keyboard.GetState().IsKeyDown(Keys.M))
                    {
                        gameState = GAMESTATE.PLAYING;
                        ResetGame();
                        
                    }
                    break;
                case GAMESTATE.PLAYING:
                    enemyManager.Update(gameTime);
                    towerManager.Update(gameTime);

                    foreach (Enemy enemy in enemyManager.enemies)
                    {
                        foreach (Tower tower in towerManager.towers)
                        {
                            float Dx = tower.position.X - enemy.hitBox.X;
                            float Dy = tower.position.Y - enemy.hitBox.Y;
                            float distance = (Dx * Dx) + (Dy * Dy);
                            float radiusSquared = tower.range * tower.range;
                            if (distance <= radiusSquared)
                            {
                                tower.enemiesInRange.Add(enemy);
                            }
                            else
                            {

                                tower.enemiesInRange.Remove(enemy);

                            }
                        }
                    }
                    break;
                case Game1.GAMESTATE.LOST:
                    if (Keyboard.GetState().IsKeyDown(Keys.M))
                    {
                        gameState = GAMESTATE.PLAYING;
                        ResetGame();
                    }
                break;
            }
            

            base.Update(gameTime);
        }

        void ResetGame()
        {
            gameState = GAMESTATE.PLAYING;
            gamemodeManager.Reset();
            enemyManager.Reset();
            towerManager.Reset();
            towerManager.towers.Add(new Tower(AssetManager.allTextures[3], new Vector2(330, 450), new Rectangle(330, 450, 40, 40), 250, 25, 500, 0, 500,Color.Red));
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.Transparent);

            _spriteBatch.Begin();
            towerManager.Draw(_spriteBatch);

            gamemodeManager.Draw(_spriteBatch);

            enemyPath.DrawFill(GraphicsDevice, AssetManager.allTextures[0]);
            _spriteBatch.End();
            _spriteBatch.Begin();
            enemyManager.Draw(_spriteBatch);


            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Green);

            _spriteBatch.Begin();
            _spriteBatch.Draw(AssetManager.allTextures[4], new Rectangle(0, 0, 1280, 720), new Rectangle(0, 0, 600, 400), Color.White);
            _spriteBatch.Draw(renderTarget, Vector2.Zero, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}