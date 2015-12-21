using System.Collections.Generic;
using LaharaGame.GameObjects.Characters;

namespace LaharaGame.Interfaces
{
    using Microsoft.Xna.Framework.Input;
    using LaharaGame.Data;

    public interface IAttack
    {
        int AttackPoints { get; set; }

        void Attack(KeyboardState state, IMap map, List<Character> characters);
    }
}
