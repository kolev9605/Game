namespace LaharaGame.Interfaces
{
    public interface IMapFactory
    {
        void Initialize(IMap map, string src, ITileFactory tileFactory);
    }
}