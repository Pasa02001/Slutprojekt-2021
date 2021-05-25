using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Enemy : BaseClass, IMoveable
    {
        private WeaponHandler weaponHandler;

        private float speed; 
        public Enemy(Texture2D texture, Vector2 texturePos, float angle, WeaponHandler weaponHandler) : base(texture, texturePos, angle)
        {
            this.weaponHandler = weaponHandler;
            hitBox.Size = new Point(90, 90);
        }

        public override void Update()
        {
            Move();

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Enemy, HitBox, null, Color.White, angle, new Vector2(Assets.Player.Width / 2, Assets.Player.Height / 2), SpriteEffects.None, 0);
        }

        public void Search()
        {
            Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            speed = 1.5f;
            texturePos += direction * speed * 2; 
        }

        public void Move()
        {
            angle = (float)Math.Atan2(texturePos.Y - Player.CurrentPlayerPos.Y, texturePos.X - Player.CurrentPlayerPos.X) + (float)(Math.PI);
            hitBox.Location = texturePos.ToPoint();

            Search();
        }
    }
}
