﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class EnemySpawner
    {
        private List<Enemy> enemies = new List<Enemy>();
        private List<Bullet> bullets = new List<Bullet>();
        private Random rnd = new Random();

        private float time = 0;
        private int maxEnemies = 5;
        private float spawnInterval = 10;

        public EnemySpawner(List<Enemy> enemies, List<Bullet> bullets1)
        {
            this.enemies = enemies;
            bullets = bullets1;
        }


        public void Update(GameTime gameTime)
        {
            time += (float)Game1.Time.ElapsedGameTime.TotalSeconds;

            int x;
            int y;
            do
            {
                x = rnd.Next(0, 4000);
                y = rnd.Next(0, 4000);
            } while (DistanceFromPlayer(x, y));

            if (enemies.Count < maxEnemies)
            {
                enemies.Add(new Enemy(Assets.Player ,new Vector2(x, y), 0, new WeaponHandler(bullets)));
            }

            EnemyLimit();
        }

        private bool DistanceFromPlayer(int x, int y)
        {
            return x >= Player.CurrentPlayerPos.X + 500
                || x <= Player.CurrentPlayerPos.X - 500
                && y >= Player.CurrentPlayerPos.Y + 500
                || y <= Player.CurrentPlayerPos.Y - 500;
        }

        private void EnemyLimit()
        {
            if (time > spawnInterval)
            {
                maxEnemies += 5;
                time -= spawnInterval;
                spawnInterval += 10;
            }
        }
    }
}
