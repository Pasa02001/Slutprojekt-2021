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



        /// <summary>
        /// Används för texturernas position (I de ollika klasserna)
        /// </summary>
        public Vector2 Position
        {
            get => texturePos;
            set => texturePos = value; 
        }
       
        /// <summary>
        /// Objektets storlek 
        /// </summary>
        public Rectangle HitBox
        {
            get => hitBox;
        }

        
        public BaseClass(Texture2D texture, Vector2 texturePos, float angle, Vector2 mousePos)
        {
            this.texture = texture;
            this.texturePos = texturePos;
            this.angle = angle;
            this.mousePos = mousePos;
        }
     
        public BaseClass(Texture2D texture, Vector2 texturePos, float angle)
        {
            this.texture = texture;
            this.texturePos = texturePos;
            this.angle = angle;
            this.mousePos = Vector2.Zero;
        }
    
        public abstract void Update();


        public abstract void Draw(SpriteBatch spriteBatch);
        

    }
}
