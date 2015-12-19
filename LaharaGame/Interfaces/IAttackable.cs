namespace LaharaGame.Interfaces
{
    public interface IAttackable
    {
        int HealthPoints { get; set; }
        int DefensePoints { get; set; }
        bool isAlive { get; set; }
    }
}
