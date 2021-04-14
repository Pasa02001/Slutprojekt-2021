using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Player : BaseClass
    {
        Vector2 mousePos;

        public Player(Texture2D texture, Vector2 texturePos, float angle) : base(texture, texturePos, angle)
        {

        }
        public override void Update()
        {
            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.W))
                texturePos.Y -= 5;
            if (kState.IsKeyDown(Keys.S))
                texturePos.Y += 5;
            if (kState.IsKeyDown(Keys.D))
                texturePos.X += 5;
            if (kState.IsKeyDown(Keys.A))
                texturePos.X -= 5;

            mousePos = Mouse.GetState().Position.ToVector2();
            angle = (float)Math.Atan2(texturePos.Y - mousePos.Y, texturePos.X - mousePos.X) + (float)(Math.PI);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            int width = (int)(Game1.ScreenHeight * .08f);
            int height = (int)(Game1.ScreenHeight * .08f);
            spriteBatch.Draw(texture, new Rectangle((int)texturePos.X, (int)texturePos.Y, width, height), null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0);
        }

        private void Shoot(Vector2 mousePos)
        {
            Vector2 dir = mousePos - texturePos;
            dir.Normalize();
        }
    }
}