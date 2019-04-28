using System;
using System.Collections.Generic;
using System.Text;

namespace RpgeOpen.Models.Entities
{
    public class Map
    {
        public string DisplayName { get; set; }
        public string TmxPath { get; set; }
        public Size NumTiles { get; protected set; }
        public PassabilityType[,] PassabilityLayer { get; set; }

        protected Map() { }

        public Map(string tmxPath, Size numTiles)
        {
            TmxPath = DisplayName = tmxPath;
            NumTiles = numTiles;
            PassabilityLayer = new PassabilityType[numTiles.Width, numTiles.Height];
        }
    }
}
