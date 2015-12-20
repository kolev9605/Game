namespace LaharaGame.Interfaces
{
    using Data;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public interface IAct
    {
        void Act(KeyboardState state, IMap map, MonsterData data);

        void Update(GameTime gameTime);

        void LoadContent(ContentManager content);

        void Draw(SpriteBatch spriteBatch);
    }
}