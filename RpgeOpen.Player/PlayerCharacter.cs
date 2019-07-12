using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using RpgeOpen.Core.Sprites;

namespace RpgeOpen.Player
{
    public class PlayerCharacter
    {
        private SpriteCharacter player;
        private Texture2D playerSpriteSheet;

        public Point Position {
            get => player.Position;
            set { player.Position = value; }
        }
    }
}
