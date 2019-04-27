using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using RpgeOpen.Core.SpriteSheets;

namespace RpgeOpen.Player
{
    public class PlayerCharacter
    {
        private Sprite player;
        private Texture2D playerSpriteSheet;

        public Vector2 Position {
            get => player.Position;
            set { player.Position = value; }
        }
    }
}
