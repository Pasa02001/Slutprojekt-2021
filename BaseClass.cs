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
        protected Rectangle hitBox;
        protected Vector2 mousePos;



        public Vector2 Position
        {
            get => texturePos;
            set => texturePos = value; 
        }
        /// <summary>
        /// Används för att texturernas position (I de ollika klasserna)
        /// </summary>
        public Rectangle HitBox
        {
            get => hitBox;
        }

        /// <summary>
        /// Objektets storlek 
        /// </summary>
        public BaseClass(Texture2D texture, Vector2 texturePos, float angle, Vector2 mousePos)
        {
            this.texture = texture;
            this.texturePos = texturePos;
            this.angle = angle;
            this.mousePos = mousePos;
        }
        /// <summary>
        /// 
        /// </summary>
        public BaseClass(Texture2D texture, Vector2 texturePos, float angle)
        {
            this.texture = texture;
            this.texturePos = texturePos;
            this.angle = angle;
            this.mousePos = Vector2.Zero;
        }
        /// <summary>
        /// 
        /// </summary>
        public abstract void Update();


        public abstract void Draw(SpriteBatch spriteBatch);
        

    }
}