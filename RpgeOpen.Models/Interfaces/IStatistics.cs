namespace RpgeOpen.Models.Interfaces
{
    public interface IStatistics
    {
        float Health { get; }
        float Mp { get; }
        float Def { get; }
        float Stamina { get; }
        float MagDef { get; }
        float Speed { get; }
        float Luck { get; }
    }
}
