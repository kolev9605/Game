using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;
using Teamwork_OOP.States;
using Teamwork_OOP.Maps;
using System.Diagnostics;

namespace Teamwork_OOP.Engine
{
    public class Engine : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;

        // TODO: extract to character class
        Texture2D character;
        Vector2 charPos;

        public Engine()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";

            this.map = new Map();
            this.charPos = new Vector2(0, 0);

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            // Load map and character textures
            map.Texture = this.Content.Load<Texture2D>("map");
            character = this.Content.Load<Texture2D>("seen");
        }
        
        protected override void UnloadContent()
        {
            ScreenManager.Instance.UnloadContent();
        }
        
        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
                Exit();

            if (state.IsKeyDown(Keys.Right))
                charPos.X += 1;
            if (state.IsKeyDown(Keys.Down))
                charPos.Y += 1;
            if (state.IsKeyDown(Keys.Left))
                charPos.X -= 1;
            if (state.IsKeyDown(Keys.Up))
                charPos.Y -= 1;
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin();

            spriteBatch.Draw(map.Texture, map.Position);
            spriteBatch.Draw(character, charPos);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
