using LaharaGame.Data;

namespace LaharaGame.Interfaces
{
    public interface IMovable
    {
        int StepSize { get; set; }

        int TextureWidth { get; set; }

        int TextureHeight { get; set; }

        void MoveRight(IMovable dude, IMap map, MonsterData data);

        void MoveLeft(IMovable dude, IMap map, MonsterData data);

        void MoveUp(IMovable dude, IMap map, MonsterData data);

        void MoveDown(IMovable dude, IMap map, MonsterData data);


        void IncrementX(int value);

        void IncrementY(int value);
    }
}

