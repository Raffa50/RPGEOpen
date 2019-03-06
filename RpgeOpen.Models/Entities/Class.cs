using System.Collections.Generic;

using RpgeOpen.Models.Interfaces;

namespace RpgeOpen.Models.Entities
{
    public class Class
    {
        public string Name { get; set; }
        public int MaxLevel { get; set; } = 99;
        public IStatistics BasicStats { get; set; } = new Statistics();
        public IList<HashSet<Skill>> SkillsLevelLearn { get; set; } = new List<HashSet<Skill>>();
    }
}
