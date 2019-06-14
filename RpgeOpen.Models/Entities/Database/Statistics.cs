using RpgeOpen.Models.Interfaces;

namespace RpgeOpen.Models.Entities
{
    public class Statistics : IStatistics {
        public virtual float Hp { get; set; }

        public virtual float Mp { get; set; }

        public virtual float Atk { get; set; }

        public virtual float Def { get; set; }

        public virtual float Stamina { get; set; }

        public virtual float MagDef { get; set; }

        public virtual float Speed { get; set; }

        public virtual float Luck { get; set; }

        public virtual float Mat { get; set; }
    }
}
