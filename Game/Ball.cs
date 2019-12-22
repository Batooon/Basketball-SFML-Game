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

        const string CONTENT_DIR = "..\\Content\\";

        public Texture ballTexture;
        CircleShape circleShape;

        public Ball()
        {
            ballTexture = new Texture(CONTENT_DIR + "Textures\\ball.png");
            circleShape = new CircleShape(BALL_SIZE * 0.5f);

            circleShape.Texture = ballTexture;
            circleShape.TextureRect = new IntRect(0, 0, 1979, 1974);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(circleShape, states);
        }
    }
}
