﻿using Microsoft.Xna.Framework;
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
        protected Vector2 mousePos;

        public Rectangle HitBox
        {
            get => hitBlox;
        }
        public BaseClass(Texture2D texture, Vector2 texturePos, float angle, Vector2 mousePos)
        {
            this.texture = texture;
            this.texturePos = texturePos;
            this.angle = angle;
            this.mousePos = mousePos;
        }
        public abstract void Update();


        public abstract void Draw(SpriteBatch spriteBatch);
        

    }
}