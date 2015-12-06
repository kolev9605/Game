using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Teamwork_OOP.Screens
{
    public class SplashScreen : GameScreen
    {
        private Texture2D image;
        private string path;

        public override void LoadContent()
        {
            base.LoadContent();
            this.path = "seen";
            this.image = this.content.Load<Texture2D>(this.path);

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image,Vector2.Zero,Color.AliceBlue);
        }
    }
}