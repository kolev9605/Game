using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Teamwork_OOP.Screens
{
    public class SplashScreen : GameScreen
    {
        private Texture2D image;
        private string path;
        private Vector2 pos;

        public override void LoadContent()
        {
            base.LoadContent();
            this.path = "seen";
            this.image = this.content.Load<Texture2D>(this.path);
            this.pos.X = 200;
            this.pos.Y = 300;

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, pos, Color.AliceBlue);
        }
    }
}