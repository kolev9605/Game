using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Teamwork_OOP.Extentions;
using Teamwork_OOP.GameObjects;
using Teamwork_OOP.GameObjects.Characters;
using Teamwork_OOP.GameObjects.Characters.PlayerClasses;
using Teamwork_OOP.GameObjects.Map;
using Teamwork_OOP.InputHandler;

namespace Teamwork_OOP.Engine
{
    public class Engine : Game
    {

        //TODO make Possition of player a structure

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;


        //extract the texture loading
        private Player player;
        private Enemy enemy;
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


            this.player = new Warrior(Vector2.Zero);
            this.enemy = new Enemy(new Vector2(500, 100));


            this.map = new Map();
            this.map.Initialize();

            
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.IsMouseVisible = true;
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.player.LoadContent(this.Content);
            this.enemy.LoadContent(this.Content);

            TextureHandler.Load(this.Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState state = Keyboard.GetState();
            this.player.Move(state,this.map);
            this.player.Update(gameTime);
            this.enemy.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //TODO UNCOMMENT THESE
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            this.spriteBatch.Begin();
            //begin draw

            //this.spriteBatch.Draw(this.camera.CameraTexture, this.camera.CameraPossition);
            this.map.Tiles.ForEach(tile => this.spriteBatch.Draw(TextureHandler.GetTexture(tile.Type), tile.Position));
            this.player.Draw(this.spriteBatch);
            this.enemy.Draw(this.spriteBatch);

            //end draw
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
