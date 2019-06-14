using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RpgeOpen.Core.Interfaces;
using RpgeOpen.Models;

namespace RpgeOpen.Core.SpriteSheets
{
    public class Sprite : IGameObject {
        public Point CornerLeft => new Point(Position.X - Size.Width / 2, Position.Y - Size.Height / 2);
        public Point Position { get; set; } // => new Point(CornerLeft.X + Size.Width/2, CornerLeft.Y + Size.Height/2);
        public bool IsMoving { get; set; }
        public Direction Direction { get; set; } = Direction.Down;
        /// <summary>
        /// Time to change frame
        /// </summary>
        public TimeSpan FrameTime { get; set; } = TimeSpan.FromSeconds(0.33);
        public Rectangle Box => new Rectangle(CornerLeft, new Point(Size.Width, Size.Height));

        /// <summary>
        /// NumTiles of the sprite
        /// </summary>
        public Size Size { get; private set; }
        private readonly Texture2D spriteSheet;
        private TimeSpan previusFrameTime = TimeSpan.Zero;
        private byte frame = 0;

        public Sprite( Texture2D spriteSheet, Size size ) {
            this.spriteSheet = spriteSheet ?? throw new ArgumentNullException(nameof(spriteSheet));
            this.Size = size;
        }

        public void Dispose()
        {
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch) {
            int offset = Size.Height;
            switch( Direction ) {
                case Direction.Down:
                    offset = 0;
                    break;
                case Direction.Left:
                    break;
                case Direction.Right:
                    offset *= 2;
                    break;
                case Direction.Up:
                    offset *= 3;
                    break;
            }
            spriteBatch.Draw(spriteSheet, CornerLeft.ToVector2(), new Rectangle(frame * Size.Width, offset, Size.Width, Size.Height), Color.White);
        }

        public void Initialize()
        {
        }

        public void LoadContent(ContentManager Content)
        {
        }

        public void Update(GameTime time) {
            if( !IsMoving )
                return;

            var now = time.TotalGameTime;
            if (now - previusFrameTime >= FrameTime ) {
                frame = (byte)(( ++frame ) % 3);
                previusFrameTime = now;
            }
        }
    }
}
