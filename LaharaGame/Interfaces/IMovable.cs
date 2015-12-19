namespace LaharaGame.Interfaces
{
    public interface IMovable
    {
        int StepSize { get; set; }

        int TextureWidth { get; set; }

        int TextureHeight { get; set; }

        void MoveRight(IMovable dude, IMap map);

        void MoveLeft(IMovable dude, IMap map);

        void MoveUp(IMovable dude, IMap map);

        void MoveDown(IMovable dude, IMap map);


        void IncrementX(int value);

        void IncrementY(int value);
    }
}

