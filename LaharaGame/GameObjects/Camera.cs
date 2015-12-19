namespace LaharaGame.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class Camera : GameObject
    {
        private Vector2 cameraPossition; // position on the matrix (x,y)
        private Texture2D cameraTexture;

        public Camera(Texture2D texture, Vector2 possition)
        {
            this.CameraTexture = texture;
            this.CameraPossition = possition;
        }

        public Vector2 CameraPossition
        {
            get { return this.cameraPossition; }
            set { this.cameraPossition = value; }
        }
        public Texture2D CameraTexture
        {
            get { return this.cameraTexture; }
            set { this.cameraTexture = value; }
        }
    }
}
