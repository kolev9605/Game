using Microsoft.Xna.Framework;

namespace Teamwork_OOP.Interfaces
{
    public interface IMovable
    {
        Vector2 Position { get; set; }

        void IncrementX(int value);
        void IncrementY(int value);
    }
}

