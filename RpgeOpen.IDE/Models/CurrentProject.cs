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
        public ProjectDetails Project { get; }
        public string FileName { get; }
        public string Directory { get; }

        public CurrentProject(string file)
        {
            var raw = File.ReadAllText(file);
            Project = JsonConvert.DeserializeObject<ProjectDetails>(raw);
            FileName = Path.GetFileNameWithoutExtension(file);
            Directory = Path.GetDirectoryName(file);
        }

        public void Save()
        {
            File.WriteAllText(Path.Combine(Directory, FileName+".rpgeo"), JsonConvert.SerializeObject(Project));
        }
    }
}
