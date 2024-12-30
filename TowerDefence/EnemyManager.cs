﻿using CatmullRom;
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
        List<Enemy> enemies;
        int timeToNextSpawn = 0;
        int spawnTimer = 400;
        int maxEnemies = 3;
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
        }

        public void LoadWave(GameTime gameTime)
        {
            timeToNextSpawn += gameTime.ElapsedGameTime.Milliseconds;
            if (currentEnemies < maxEnemies)
            {
                if (timeToNextSpawn > spawnTimer)
                {
                    timeToNextSpawn -= spawnTimer;
                    Enemy enemy = new Enemy(path);
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