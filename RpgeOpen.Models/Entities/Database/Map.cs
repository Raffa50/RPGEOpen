using Newtonsoft.Json;
using RpgeOpen.Models.Entities.Database;
using RpgeOpen.Models.Exceptions;
using RpgeOpen.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [JsonProperty]
        public ICollection<Event> events { get; } = new List<Event>();
        [JsonIgnore]
        public IEnumerable<Event> Events => events;

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

        public void AddEvent(string id, int x, int y)
        {
            if (!Constants.VariableNameRegex.IsMatch(id))
                throw new ArgumentException("id already present", nameof(id));
            if (Events.Any(e => e.Id == id))
                throw new KeyAlreadyExistException("the specified key already exist in the collection", id);

            if (x < 0 || x >= NumTiles.Width)
                throw new ArgumentOutOfRangeException(nameof(x));
            if (y < 0 || y >= NumTiles.Height)
                throw new ArgumentOutOfRangeException(nameof(y));
        }
    }
}
