using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Teamwork_OOP.GameObjects;
using Teamwork_OOP.GameObjects.Characters;
using Teamwork_OOP.GameObjects.Map;
using Teamwork_OOP.InputHandler;
using Teamwork_OOP.States;

namespace Teamwork_OOP.Engine
{
    public class Engine : Game
    {

        //TODO make Possition of player a structure

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;


        //extract the texture loading
        private Player player;
        private Camera camera;

        private Map map;

        public Engine()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //this.graphics.PreferredBackBufferWidth = (int) ScreenManager.Instance.Dimention.X;
            //this.graphics.PreferredBackBufferHeight = (int) ScreenManager.Instance.Dimention.Y;
            //this.graphics.ApplyChanges();


            this.player = new Player(this.Content.Load<Texture2D>("seen"), Vector2.Zero);
            //this.camera = new Camera(this.Content.Load<Texture2D>("map"), Vector2.Zero);


            this.map = new Map();
            this.map.Initialize();

            
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.IsMouseVisible = true;
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            TextureHandler.Load(Content);
        }

        protected override void UnloadContent()
        {
            //ScreenManager.Instance.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState state = Keyboard.GetState();


            if (state.IsKeyDown(Keys.Right))
                this.player.IncrementX(this.player.StepSize);
            if (state.IsKeyDown(Keys.Down))
                this.player.IncrementY(this.player.StepSize);
            if (state.IsKeyDown(Keys.Left))
                this.player.IncrementX(-this.player.StepSize);
            if (state.IsKeyDown(Keys.Up))
                this.player.IncrementY(-this.player.StepSize);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            this.spriteBatch.Begin();
            //begin draw

            //this.spriteBatch.Draw(this.camera.CameraTexture, this.camera.CameraPossition);
            this.map.Tiles.ForEach(tile => this.spriteBatch.Draw(TextureHandler.GetTexture(tile.Type), tile.Position));
            this.spriteBatch.Draw(this.player.CharacterTexture, this.player.CharacterPosition);

            


            //end draw
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
