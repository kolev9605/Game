using System.Collections.Generic;
using LaharaGame.GameObjects.Characters;

namespace LaharaGame.Interfaces
{
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public interface IAct
    {
        void Act(KeyboardState state, IMap map, List<Character> characters);

        void Update(GameTime gameTime);

        void LoadContent(ContentManager content);

        void Draw(SpriteBatch spriteBatch);
    }
}