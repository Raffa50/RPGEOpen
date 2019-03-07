using RpgeOpen.Models.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpgeOpen.Models.Entities
{
    public class Map
    {
        public string DisplayName { get; set; }
        public string TmxPath { get; set; }
        public Size Size { get; set; }
        public PassabilityType[,] PassabilityLayer { get; set; }

        private Map() { }

        public Map(string tmxPath, Size size)
        {
            TmxPath = DisplayName = tmxPath;
            Size = size;
            PassabilityLayer = new PassabilityType[size.Width, size.Height];
        }
    }
}
