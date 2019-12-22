using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Ball:Transformable,Drawable
    {
        public const int BALL_SIZE = 100;

        const string CONTENT_DIR = "..\\Content\\Textures\\ball.png";

        public Texture ballTexture;
        CircleShape ball;

        public void LoadContent()
        {
            ballTexture = new Texture(CONTENT_DIR);
        }

        public Ball()
        {

        }

        public void DisplayBall(GameLoop gameLoop)
        {
            ball = new CircleShape(BALL_SIZE * 0.5f);

            ball.Texture = ballTexture;
            ball.TextureRect = new IntRect(0, 0, 1979, 1974);
            ball.Position = new Vector2f(800f, 450f);

            gameLoop.Window.Draw(this);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(ball, states);
        }
    }
}
