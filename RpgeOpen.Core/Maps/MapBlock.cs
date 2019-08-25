using Microsoft.Xna.Framework;
using RpgeOpen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgeOpen.Core.Maps
{
    public class MapBlock
    {
        public PassabilityType Passability { get; }
        public Rectangle Box { get; }

        public MapBlock(PassabilityType passability, Size tileSize, int x, int y)
        {
            Passability = passability;
            Box = new Rectangle(x * tileSize.Width +3, y * tileSize.Height +3, tileSize.Width -3, tileSize.Height -3);
        }
    }
}
