﻿using System;
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
        public Vector2 Position { get; set; }
        public bool IsMoving { get; set; }
        public Direction Direction { get; set; } = Direction.Down;
        /// <summary>
        /// Time to change frame
        /// </summary>
        public TimeSpan FrameTime { get; set; } = TimeSpan.FromSeconds(0.33);

        /// <summary>
        /// Size of the sprite
        /// </summary>
        private readonly Size size;
        private readonly Texture2D spriteSheet;
        private TimeSpan previusFrameTime = TimeSpan.Zero;
        private byte frame = 0;

        public Sprite( Texture2D spriteSheet, Size size ) {
            this.spriteSheet = spriteSheet ?? throw new ArgumentNullException(nameof(spriteSheet));
            this.size = size;
        }

        public void Dispose()
        {
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch) {
            int offset = size.Height;
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
            spriteBatch.Draw(spriteSheet, Position, new Rectangle(frame * size.Width, offset, size.Width, size.Height), Color.White);
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