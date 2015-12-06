using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teamwork_OOP.Interfaces
{
    public interface IAttackable
    {
        int HealthPoints { get; set; }
        int DefensePoints { get; set; }
        bool isAlive { get; set; }
    }
}
