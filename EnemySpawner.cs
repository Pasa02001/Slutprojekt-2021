using Microsoft.Xna.Framework;
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
        private Vector2 door;

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


            Vector2 door1 = new Vector2(384,0);
            Vector2 door2 = new Vector2(0,480);
            
            if (rnd.Next(0,100) > 50)
            {
                door = door1;
            }
            else
            {
                door = door2;
            }
            
            if (enemies.Count < maxEnemies)
            {
                enemies.Add(new Enemy(Assets.Player , door, 0, new WeaponHandler(bullets)));
            }

            EnemyLimit();
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
