using Microsoft.Xna.Framework;

namespace Teamwork_OOP.Interfaces
{
    public  interface ITileFactory
    {
        ITile Make(string type, bool isSteppable, Vector2 position);
    }
}