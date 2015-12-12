using Microsoft.Xna.Framework;
using Teamwork_OOP.GameObjects.Map;

namespace Teamwork_OOP.Interfaces
{
    public interface IMovable
    {
        int StepSize { get; set; }

        int TextureWidth { get; set; }

        int TextureHeight { get; set; }
        

        void MoveRight(IMovable dude, Map map);

        void MoveLeft(IMovable dude, Map map);

        void MoveUp(IMovable dude, Map map);

        void MoveDown(IMovable dude, Map map);


        void IncrementX(int value);

        void IncrementY(int value);
    }
}

