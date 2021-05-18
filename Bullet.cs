using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Bullet : BaseClass
    {

        private Point size = new Point(20, 20);
        private Vector2 speed;
        private Damage damage;
        public Damage GetDamage
        {
            get => damage;
            set => damage = value;
        }
        public Bullet(Vector2 texturePos, float angle, Vector2 speed, Point size, Vector2 mousePos, Damage damage) : base(Assets.BulletTexture, texturePos, angle, mousePos)
        {
            this.damage = damage;
            hitBox.Size = this.size;
            this.speed = speed;
        }

        public override void Update()
        {
            texturePos += new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 50;

            hitBox.Location = texturePos.ToPoint();



           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.BulletTexture, HitBox, null, Color.White, angle, new Vector2(texturePos.X + texture.Width / 2, texturePos.Y + texture.Height / 2), SpriteEffects.None, 0);
        }
    }



    enum Damage{
        player,
        enemy 
    }
}
