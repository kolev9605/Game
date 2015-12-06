using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teamwork_OOP.Interfaces
{
    public interface IAttack
    {
        int AttackPoints { get; set; }

        void Attack(IAttackable target);
    }
}
