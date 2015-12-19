using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Teamwork_OOP.Interfaces
{
    public interface IAttack
    {
        int AttackPoints { get; set; }

        void Attack(KeyboardState state, IMap map);
    }
}
