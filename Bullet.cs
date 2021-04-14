using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Bullet : BaseClass
    {

        private Point size = new Point(6, 6);
        private Vector2 speed;
        private Damage damage;
        public Damage GetDamage
        {
            get => damage;
            set => damage = value;
        }
        public Bullet(Texture2D texture, Vector2 texturePos, float angle, Damage damage, Vector2 speed, Point size) : base(texture, texturePos, angle)
        {
            this.damage = damage;
            hitBlox.Size = this.size;
            this.speed = speed;
        }

        public override void Update()
        {
            texturePos += new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 5;

            hitBlox.Location = texturePos.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw();
        }
    }



    enum Damage{
        player,
        enemy 
    }
}
