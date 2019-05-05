using System.Collections.Generic;

using RpgeOpen.Models.Interfaces;

namespace RpgeOpen.Models.Entities
{
    public class Class
    {
        public string Name { get; set; }
        public int MaxLevel { get; set; } = 99;
        public IStatistics BasicStats { get; set; } = new Statistics();
        public IList<List<int>> SkillsLevelLearn { get; private set; } = new List<List<int>>();
    }
}
