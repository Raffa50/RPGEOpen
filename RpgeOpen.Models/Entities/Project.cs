using System;
using System.Collections.Generic;
using System.Text;

namespace RpgeOpen.Models.Entities
{
    public class Project
    {
        public static class Paths
        {
            public const string 
                TileSheets = "TileSheets", 
                Maps = "Maps",
                Characters = "Characters",
                Backgrounds = "Backgrounds",
                AudioBgm = "Audio/Bgm";
        }

        public string Name { get; set; }
        public string Author { get; set; } = Environment.UserName;
        public ICollection<Map> Maps { get; set; } = new List<Map>();

        private Project() { }
        public Project(string name)
        {
            Name = name;
        }
    }
}
