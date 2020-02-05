using SFML.System;
using Game.Interfaces;
using Game.Utils;

namespace Game.Units
{
    public class Ball : Actor, IUpdatable
    {
        public const int BALL_DIAMETER = 200;
        public const float BALL_RADIUS = BALL_DIAMETER * .5f;
        private const float JUMP_KOEF = 0.95f;
        private const int SCREEN_WIDTH = 1600;
        private const int SCREEN_HEIGHT = 900;
        private const float ENERGY = 0.99f;
        private const int INCREASER = 250;

        private float _accelerationModifier = 10f;

        private Vector2f _velocity = new Vector2f(100f, 100f);
        public Vector2f GetVelocity() => _velocity;
        private Vector2f offsetPosition = new Vector2f(BALL_RADIUS, BALL_RADIUS);

        public void Hit(Vector2i punchPosition)
        {
            Vector2f punchVector = form.Position + offsetPosition - (Vector2f)punchPosition;

            _velocity += punchVector * _accelerationModifier;
        }

        public bool IsPointInside(Vector2i point)
        {
            return point.DistanceTo(form.Position + offsetPosition) < BALL_RADIUS;
        }

        public void Update(float deltaTime)
        {
            CheckForCollide();

            _velocity.Y += INCREASER * deltaTime;
            _velocity *= ENERGY;

            form.Position += _velocity * deltaTime;
        }

        public void CheckForCollide()
        {
            if (form.Position.X + offsetPosition.X <= BALL_RADIUS && _velocity.X < 0)
                _velocity.X *= -JUMP_KOEF;
            if (form.Position.X + offsetPosition.X >= SCREEN_WIDTH - BALL_RADIUS && _velocity.X > 0)
                _velocity.X *= -JUMP_KOEF;
            if (form.Position.Y + offsetPosition.Y <= BALL_RADIUS && _velocity.Y < 0)
                _velocity.Y *= -JUMP_KOEF;
            if (form.Position.Y + offsetPosition.Y >= SCREEN_HEIGHT - BALL_RADIUS && _velocity.Y > 0)
                _velocity.Y *= -JUMP_KOEF;
        }
    }
}
