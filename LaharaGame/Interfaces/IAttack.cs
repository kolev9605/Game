namespace LaharaGame.Interfaces
{
    using Microsoft.Xna.Framework.Input;

    public interface IAttack
    {
        int AttackPoints { get; set; }

        void Attack(KeyboardState state, IMap map);
    }
}
