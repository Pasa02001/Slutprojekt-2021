using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Player : BaseClass, IMoveable
    {
        private MouseState old;
        private MouseState current;
        public static Vector2 CurrentPlayerPos;

        private WeaponHandler weaponHandler;


        Vector2 mousePos;

        public Player(Texture2D texture, Vector2 texturePos, float angle, Vector2 mousePos) : base(texture, texturePos, angle, mousePos)
        {

        }
        public override void Update()
        {


            Move();


            mousePos = Mouse.GetState().Position.ToVector2();
            angle = (float)Math.Atan2(texturePos.Y - mousePos.Y, texturePos.X - mousePos.X) + (float)(Math.PI);


            old = current;
            current = Mouse.GetState();

           

            if (current.LeftButton == ButtonState.Pressed && old.LeftButton == ButtonState.Released)
            {
                weaponHandler.Shoot(texturePos, angle, new Vector2(), new Point(), mousePos, Damage.player);
                
            }

            old = Mouse.GetState();

            CurrentPlayerPos = new Vector2(texturePos.X, texturePos.Y);
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

        public void SetWeaponHandler(WeaponHandler wH)
        {
            weaponHandler = wH;
        }

        public void Move()
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


            if (texturePos.X <= 96)
            {
                texturePos.X = 96;
            }
            if (texturePos.X >= 1824)
            {
                texturePos.X = 1824;
            }
            if (texturePos.Y <= 96)
            {
                texturePos.Y = 96;
            }
            if (texturePos.Y >= 960)
            {
                texturePos.Y = 960;
            }

        }
    }
}