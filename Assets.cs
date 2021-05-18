using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    static class Assets
    {
        public static Texture2D Player { get; private set; }
        public static Texture2D stoneGround { get; private set; }

        // Alla väggar
        public static Texture2D stoneWall { get; private set; }
        public static Texture2D wallLeft { get; private set; }
        public static Texture2D wallTop { get; private set; }
        public static Texture2D wallBut { get; private set; }
        public static Texture2D wallRight { get; private set; }
        // Vägar


        public static Texture2D rock { get; private set; }
        public static Texture2D chair { get; private set; }

        public static Texture2D BulletTexture { get; private set; }

        public static Texture2D Enemy { get; private set; }
  


        public static void LoadAssets(ContentManager Content, GraphicsDevice graphics)
        {
            Player = Content.Load<Texture2D>("Player");
            stoneWall = Content.Load<Texture2D>("StoneWall");
            BulletTexture = Content.Load<Texture2D>("Bullet");
            Enemy = Content.Load<Texture2D>("Enemy");
        }
    }
}
