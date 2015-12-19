namespace LaharaGame.Engine
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Extentions;
    using GameObjects;
    using GameObjects.Characters.EnemyClasses;
    using GameObjects.Characters.PlayerClasses;
    using InputHandler;
    using Interfaces;

    public class Engine : Game
    {

        //TODO make Possition of player a structure

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;


        //extract the texture loading
        private IAct player;
        private IAct shadow;
        private IAct skeleton;
        private IAct goblin;
        private IAct gargoyle;
        private IAct death;
        private Camera camera;
        private IMap map;

        public Engine(IMap map, IMapFactory mapFactory, ITileFactory tileFactory)
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.map = map;
            this.MapFactory = mapFactory;
            this.TileFactory = tileFactory;
        }

        public IMapFactory MapFactory { get; set; }

        public ITileFactory TileFactory { get; set; }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //this.graphics.PreferredBackBufferWidth = (int) ScreenManager.Instance.Dimention.X;
            //this.graphics.PreferredBackBufferHeight = (int) ScreenManager.Instance.Dimention.Y;
            //this.graphics.ApplyChanges();


            this.player = new Warrior(Vector2.Zero);
            this.shadow = new Shadow(new Vector2(200, 100));
            this.skeleton = new Skeleton(new Vector2(300, 100));
            this.goblin = new Goblin(new Vector2(500, 200));
            this.gargoyle = new Gargoyle(new Vector2(600, 10));
            this.death = new Death(new Vector2(600, 200));


            this.map.Initialize(this.MapFactory, this.TileFactory);
            
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.IsMouseVisible = true;
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.player.LoadContent(this.Content);
            this.shadow.LoadContent(this.Content);
            this.skeleton.LoadContent(this.Content);
            this.goblin.LoadContent(this.Content);
            this.gargoyle.LoadContent(this.Content);
            this.death.LoadContent(this.Content);

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
            this.player.Act(state,this.map);
            this.player.Update(gameTime);
            this.shadow.Update(gameTime);
            this.skeleton.Update(gameTime);
            this.goblin.Update(gameTime);
            this.gargoyle.Update(gameTime);
            this.death.Update(gameTime);
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
            this.shadow.Draw(this.spriteBatch);
            this.skeleton.Draw(this.spriteBatch);
            this.goblin.Draw(this.spriteBatch);
            this.gargoyle.Draw(this.spriteBatch);
            this.death.Draw(this.spriteBatch);

            //end draw
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
