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
    using Handlers;
    using Data;
    using GameObjects.Characters;
    using System.Linq;

    public class Engine : Game
    {

        //TODO make Possition of player a structure

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private NewCollisionHandler collisionHandler;
        private MonsterData monsters;
        private PlayerData players;

        //extract the texture loading
        private IAct player;
        private IAct shadow;
        private IAct skeleton;
        private IAct goblin;
        private IAct gargoyle;
        private IAct death;
        private IAct sorceror;
        private Camera camera;
        private IMap map;

        public Engine(IMap map, IMapFactory mapFactory, ITileFactory tileFactory)
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.collisionHandler = new NewCollisionHandler();
            this.monsters = new MonsterData();
            this.players = new PlayerData();
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
          

            this.player = new Warrior(new Vector2(10, 10));
            this.players.AddEnemy(player as Character);

            this.shadow = new Shadow(new Vector2(260, 10));
            this.monsters.AddEnemy(shadow as Character);
            this.skeleton = new Skeleton(new Vector2(310, 110));
            this.monsters.AddEnemy(skeleton as Character);
            this.goblin = new Goblin(new Vector2(160, 255));
            this.monsters.AddEnemy(goblin as Character);
            this.gargoyle = new Gargoyle(new Vector2(560, 10));
            this.monsters.AddEnemy(gargoyle as Character);
            this.death = new Death(new Vector2(610, 300));
            this.monsters.AddEnemy(death as Character);
            this.sorceror = new Sorceror(new Vector2(110, 410));
            this.monsters.AddEnemy(sorceror as Character);


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
            this.sorceror.LoadContent(this.Content);

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
            this.player.Act(state,this.map,monsters.enemies);
            this.player.Update(gameTime);
            this.shadow.Update(gameTime);
            this.skeleton.Update(gameTime);
            this.goblin.Update(gameTime);
            this.gargoyle.Update(gameTime);
            this.death.Update(gameTime);
            this.sorceror.Update(gameTime);
            this.monsters.enemies.RemoveAll(e => e.HealthPoints <= 0);
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
            this.sorceror.Draw(this.spriteBatch);

            //end draw
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
