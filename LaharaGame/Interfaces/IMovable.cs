using System.Collections.Generic;
using LaharaGame.GameObjects.Characters;

namespace LaharaGame.Interfaces
{
    public interface IMovable
    {
        int StepSize { get; set; }

        int TextureWidth { get; set; }

        int TextureHeight { get; set; }

        void MoveRight(IMovable dude, IMap map, List<Character> characters);

        void MoveLeft(IMovable dude, IMap map, List<Character> characters);

        void MoveUp(IMovable dude, IMap map, List<Character> characters);

        void MoveDown(IMovable dude, IMap map, List<Character> characters);


        void IncrementX(int value);

        void IncrementY(int value);
    }
}

