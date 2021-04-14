using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    public abstract class BaseClass
    {
        protected Texture2D texture;
        protected Vector2 texturePos;
        protected float angle = 0f;
        protected Rectangle hitBlox;

        public Rectangle HitBox
        {
            get => hitBlox;
        }
        public BaseClass(Texture2D texture, Vector2 texturePos, float angle)
        {
            this.texture = texture;
            this.texturePos = texturePos;
            this.angle = angle;

        }
        public abstract void Update();


        public abstract void Draw(SpriteBatch spriteBatch);
        

    }
}