using Microsoft.Xna.Framework;

namespace Teamwork_OOP.Interfaces
{
    public interface ITile
    {
        Vector2 Position { get; set; }

        bool IsSteppable { get; set; }

        string Type { get; set; }
    }
}