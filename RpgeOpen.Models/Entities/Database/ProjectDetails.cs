using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpgeOpen.Models.Entities
{
    public class ProjectDetails
    {
        public string Name { get; set; }
        public string Author { get; set; } = Environment.UserName;
        [JsonProperty]
        public IList<Map> Maps { get; private set; } = new List<Map>();

        private ProjectDetails() { }
        public ProjectDetails(string name)
        {
            Name = name;
        }
    }
}
