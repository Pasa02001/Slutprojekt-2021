using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Enemy : BaseClass
    {

        private float speed; 
        public Enemy(Vector2 texturePos, float angle, Vector2 speed, Point size) : base(Assets.Enemy, texturePos, angle)
        {
            hitBox.Size = new Point(15, 15);
        }

        public override void Update()
        {
            angle = (float)Math.Atan2(texturePos.Y - Player.CurrentPlayerPos.Y, texturePos.X - Player.CurrentPlayerPos.X) + (float)(Math.PI);
            hitBox.Location = texturePos.ToPoint();

            Search();

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Enemy, HitBox, null, Color.White, angle, new Vector2(texturePos.X + texture.Width / 2, texturePos.Y + texture.Height / 2), SpriteEffects.None, 0);
        }

        public void Search()
        {
            Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            speed = 1.5f;
            texturePos += direction * speed; 
        }
    }
}
