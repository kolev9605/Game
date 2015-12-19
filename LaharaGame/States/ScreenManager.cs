namespace LaharaGame.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ScreenManager
    {
        private static ScreenManager instance;
        public Vector2 Dimention { get; private set; }
        public ContentManager Content { get; private set; }

        private State currentScreen;

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
        }

        public ScreenManager()
        {
            this.Dimention = new Vector2(630, 480);
            this.currentScreen = new GameState();
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            this.currentScreen.LoadContent();
        }

        public void UnloadContent()
        {
            this.currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            this.currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.currentScreen.Draw(spriteBatch);
        }
    }
}
