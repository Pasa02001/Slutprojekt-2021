using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Template
{
    class BaseClass
    {
        protected Texture2D texture;
        protected Vector2 texturePos;

        public BaseClass(Texture2D texture, Vector2 texturePos)
        {
            this.texture = texture;
            this.texturePos = texturePos;

        }
        public virtual void Update()
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}