using CatmullRom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public class EnemyManager
    {
        public CatmullRomPath path;
        public List<Enemy> enemies;
        int timeToNextSpawn = 0, timeToNextWave = 0;
        int spawnTimer = 200, waveSpawnTime = 5000;
        int maxEnemies = 4;
        int currentEnemies = 0;
        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }

        public void Update(GameTime gameTime)
        {

            LoadWave(gameTime);
            foreach(Enemy enemy in enemies)
            {
                if (enemy.health > 0)
                {
                    enemy.Update(gameTime);
                }  
            }
            
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].position > 1 && enemies[i].health > 0)
                {
                    GamemodeManager.lives--;
                    enemies.RemoveAt(i);
                }
                else if (enemies[i].health <= 0)
                {
                    GamemodeManager.resources += enemies[i].pointGain;
                    enemies.RemoveAt(i);
                }
            }

            timeToNextWave += gameTime.ElapsedGameTime.Milliseconds;
            if (timeToNextWave > waveSpawnTime)
            {
                timeToNextWave = 0;
                currentEnemies = 0;
                enemies.Clear();
                LoadWave(gameTime);
                maxEnemies++;
            }


        }

        public void LoadWave(GameTime gameTime)
        {
            timeToNextSpawn += gameTime.ElapsedGameTime.Milliseconds;
            if (currentEnemies < maxEnemies)
            {
                if (timeToNextSpawn > spawnTimer)
                {
                    timeToNextSpawn = 0;
                    Enemy enemy;
                    if (maxEnemies > 8)
                    {
                        enemy = new Enemy(path, 150, 0.5f, 250);
                    }
                    else
                    {
                        enemy = new Enemy(path, 50, 0.2f, 100);
                    }
                    
                    enemies.Add(enemy);
                    currentEnemies++;
                }

            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.position < 1 & enemy.position > 0)
                {
                    if (enemy.health > 0)
                    {
                        enemy.Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
