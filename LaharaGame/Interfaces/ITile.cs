using Microsoft.Xna.Framework;

namespace LaharaGame.Interfaces
{
    public interface ITile
    {
        Vector2 Position { get; set; }

        Rectangle Bounds { get; set; }

        bool IsSteppable { get; set; }

        string Type { get; set; }
    }
}