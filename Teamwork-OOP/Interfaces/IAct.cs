using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Teamwork_OOP.Interfaces
{
    public interface IAct
    {
        void Act(KeyboardState state, IMap map);

        void Update(GameTime gameTime);

        void LoadContent(ContentManager content);

        void Draw(SpriteBatch spriteBatch);
    }
}