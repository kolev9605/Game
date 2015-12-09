using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;
using Teamwork_OOP.States;
using System.Diagnostics;

namespace Teamwork_OOP.Engine
{
    public class Engine : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // the below two lines should be extracted in the map class
        Texture2D map;
        Vector2 mapPos;

        // TODO: extract to character class
        Texture2D character;
        Vector2 charPos;

        public Engine()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            mapPos = new Vector2(0, 0);
            charPos = new Vector2(0, 0);
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //this.graphics.PreferredBackBufferWidth = (int) ScreenManager.Instance.Dimention.X;
            //this.graphics.PreferredBackBufferHeight = (int) ScreenManager.Instance.Dimention.Y;
            //this.graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            // loading of the map file
            map = this.Content.Load<Texture2D>("map");
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

            StringBuilder sb = new StringBuilder();

            foreach (var key in state.GetPressedKeys())
                sb.Append("Keys: ").Append(key).Append(" Pressed");

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            else
                System.Diagnostics.Debug.WriteLine("No keys pressed");

            if (state.IsKeyDown(Keys.Right))
                charPos.X += 1;
            if (state.IsKeyDown(Keys.Down))
                charPos.Y += 1;
            if (state.IsKeyDown(Keys.Left))
                charPos.X -= 1;
            if (state.IsKeyDown(Keys.Up))
                charPos.Y -= 1;

            //ScreenManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //this.GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            this.spriteBatch.Begin();
            //ScreenManager.Instance.Draw(this.spriteBatch);
            spriteBatch.Draw(map, mapPos);
            spriteBatch.Draw(character, charPos);

            this.spriteBatch.End();

            //base.Draw(gameTime);
        }
    }
}
