using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Template
{
    class WeaponHandler
    {
        List<Bullet> bullets = new List<Bullet>();



        public WeaponHandler(List<Bullet> bullets)
        {
            this.bullets = bullets;
            

        }

         public void Update()
        {
            foreach(Bullet item in bullets)
            {
                item.Update();
            }
        }


        public void Shoot( Vector2 playerPos, float angle, Vector2 speed, Point size, Vector2 mousPos, Damage damage)
        {
            bullets.Add(new Bullet( playerPos, angle, speed, size, mousPos, damage));
        }
    }
}
