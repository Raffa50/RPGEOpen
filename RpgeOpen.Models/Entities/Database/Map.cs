using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpgeOpen.Models.Entities
{
    public class Map
    {
        public string DisplayName { get; set; }
        [JsonProperty]
        public string TmxPath { get; private set; }
        [JsonIgnore]
        public Size NumTiles => new Size(PassabilityLayer.GetLength(0), PassabilityLayer.GetLength(1));
        [JsonProperty]
        public PassabilityType[,] PassabilityLayer { get; private set; }

        [JsonConstructor]
        private Map() { }

        protected Map(string tmxPath, PassabilityType[,] passabilityLayer)
        {
            this.TmxPath = tmxPath;
            this.PassabilityLayer = passabilityLayer;
        }

        public Map(string tmxPath, Size numTiles)
        {
            TmxPath = DisplayName = tmxPath;
            PassabilityLayer = new PassabilityType[numTiles.Width, numTiles.Height];
        }
    }
}
