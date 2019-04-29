namespace RpgeOpen.Models.Interfaces
{
    public interface IStatistics
    {
        float Hp { get; }
        float Mp { get; }
        float Atk { get; set; }
        float Def { get; }
        float Stamina { get; }
        float Mat { get; }
        float MagDef { get; }
        float Speed { get; }
        float Luck { get; }
    }
}
