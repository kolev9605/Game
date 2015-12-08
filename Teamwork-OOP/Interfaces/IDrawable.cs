using Microsoft.Xna.Framework;

namespace Teamwork_OOP.Interfaces
{
    public interface IDrawable
    {
        void LoadContent();

        void UnloadContent();

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime);
    }
}