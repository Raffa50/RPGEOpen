using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RpgeOpen.Core.Interfaces;
using RpgeOpen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgeOpen.Core.Sprites
{
    public class Sprite : IGameObject
    {
        protected readonly Texture2D spriteSheet;
        public Size Size { get; private set; }
        public Point Position { get; set; }

        public Sprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
            Size = new Size(spriteSheet.Width, spriteSheet.Height);
        }

        protected Sprite(Texture2D spriteSheet, Size size)
        {
            this.spriteSheet = spriteSheet;
            Size = size;
        }

        public virtual void Dispose()
        {
        }

        public virtual void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, Position.ToVector2(), Color.White);
        }

        public virtual void Initialize()
        {
        }

        public virtual void LoadContent(ContentManager Content)
        {
        }

        public virtual void Update(GameTime time)
        {
        }
    }
}
