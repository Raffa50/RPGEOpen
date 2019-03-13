using Newtonsoft.Json;
using RpgeOpen.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgeOpen.IDE.Models
{
    internal class CurrentProject
    {
        public Project Project { get; }
        public string FileName { get; }
        public string Directory { get; }

        public CurrentProject(string file)
        {
            var raw = File.ReadAllText(file);
            Project = JsonConvert.DeserializeObject<Project>(raw);
            FileName = file;
            Directory = Path.GetDirectoryName(file);
        }

        public void Save()
        {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(Project));
        }
    }
}
