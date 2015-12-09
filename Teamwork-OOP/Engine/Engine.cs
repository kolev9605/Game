using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;
using Teamwork_OOP.States;
using Teamwork_OOP.Maps;
using Teamwork_OOP.Characters;


namespace Teamwork_OOP.Engine
{
    public class Engine : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;
        PlayableCharacter player;

        public Engine()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";

            this.map = new Map();
            this.player = new Warrior();

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
            this.map.Texture = this.Content.Load<Texture2D>("map");
            this.player.Texture = this.Content.Load<Texture2D>("seen");
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
                this.player.MoveRight();
            if (state.IsKeyDown(Keys.Down))
                this.player.MoveDown();
            if (state.IsKeyDown(Keys.Left))
                this.player.MoveLeft();
            if (state.IsKeyDown(Keys.Up))
                this.player.MoveUp();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin();

            // Drawing of the map and character textures
            spriteBatch.Draw(map.Texture, map.Position);
            spriteBatch.Draw(player.Texture, player.Position);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
