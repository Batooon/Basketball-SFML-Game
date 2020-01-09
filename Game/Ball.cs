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
    public class Ball : Actor, IUpdatable
    {
        float accelerationModifier = 20f;
        Vector2f velocity = new Vector2f(100f, 100f);

        Vector2f ballPosition = new Vector2f();

        public const int BALL_DIAMETER = 200;
        public const float BALL_RADIUS = BALL_DIAMETER * .5f;

        Vector2f offsetPosition = new Vector2f(BALL_RADIUS, BALL_RADIUS);
          
        const string CONTENT_DIR = "..\\Content\\Textures\\ball.png";

        const float JUMP_KOEF = 0.95f;

        public Ball(ActorArgs args) : base(args)
        {
            ballPosition = form.Position;
        }

        public void LoadContent()
        {
        }

        public void Hit(Vector2i punchPosition)
        {
            Vector2f punchVector = (form.Position + offsetPosition) - (Vector2f)punchPosition;

            velocity += punchVector * accelerationModifier;
        }

        public bool IsPointInside(Vector2i point)
        {
            return point.DistanceTo(form.Position + offsetPosition) < BALL_RADIUS;
        }

        public void Update(float deltaTime)
        {
            if (form == null)
                return;

            if ((form.Position.X + offsetPosition.X) <= BALL_RADIUS && velocity.X < 0)
                velocity.X *= -JUMP_KOEF;
            if ((form.Position.X + offsetPosition.X) >= 1600 - BALL_RADIUS && velocity.X > 0)
                velocity.X *= -JUMP_KOEF;
            if ((form.Position.Y + offsetPosition.Y) <= BALL_RADIUS && velocity.Y < 0)
                velocity.Y *= -JUMP_KOEF;
            if ((form.Position.Y + offsetPosition.Y) >= 900 - BALL_RADIUS && velocity.Y > 0)
                velocity.Y *= -JUMP_KOEF;
            else
                velocity.Y += 250 * deltaTime;

            velocity *= 0.99f;


            ballPosition += velocity * deltaTime;
            form.Position = ballPosition;
        }
    }
}
