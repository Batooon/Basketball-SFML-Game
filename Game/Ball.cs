using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Ball:Transformable,Drawable
    {
        public const int BALL_SIZE = 100;

        const string CONTENT_DIR = "..\\Content\\Textures\\ball.png";

        public Texture ballTexture;
        public CircleShape ball;

        float x, y;
        float dx = 0f, dy = 0f;

        public void LoadContent()
        {
            ballTexture = new Texture(CONTENT_DIR);
            ball = new CircleShape(BALL_SIZE * 0.5f);
            ball.Texture = ballTexture;
            ball.TextureRect = new IntRect(0, 0, 1979, 1974);
            ball.Position = new Vector2f(800f, 450f);
            x = ball.Position.X;
            y = ball.Position.Y;
        }

        public Ball()
        {

        }

        public void Update(GameLoop gameLoop)
        {
            if (ball == null)
                return;

            dy += 0.2f;
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
                dx -= 0.2f;
            if (Mouse.IsButtonPressed(Mouse.Button.Right))
                dx += 0.2f;

            if (ball.Position.X <= 10f)
                dx = 10f;
            if (ball.Position.X >= 1500f)
                dx = -10f;
            if (ball.Position.Y >= 800f)
                dy = -10f;
            if (ball.Position.Y <= 100f)
                dy = 10f;

            x += dx;
            y += dy;
            ball.Position = new Vector2f(x, y);

            //Vector2f vector = new Vector2f();
            /*if (Mouse.IsButtonPressed(Mouse.Button.Left)
                && Mouse.GetPosition(gameLoop.Window).X == ball.Position.X
                && Mouse.GetPosition(gameLoop.Window).Y == ball.Position.Y)
            {
                dy += 0.2f;
                y += dy;
                if (y > 450f)
                    dy = -10;
                ball.Position = new Vector2f(x, y);
            }*/

            /*if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Vector2f mousePos = (Vector2f)Mouse.GetPosition(gameLoop.Window);
                Vector2f position = ball.Position;
                Vector2f ballPos = position;
                vector = ballPos - mousePos;
            }
            ball.Position += vector * gameLoop.GameTime.DeltaTime;*/
        }

        public void DisplayBall(GameLoop gameLoop)
        {
            gameLoop.Window.Draw(this);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(ball, states);
        }
    }
}
