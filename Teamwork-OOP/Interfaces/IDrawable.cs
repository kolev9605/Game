using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Teamwork_OOP.Interfaces
{
    public interface IDrawable
    {
        Texture2D Texture { get; set; }

        Vector2 Position { get; set; }
    }
}