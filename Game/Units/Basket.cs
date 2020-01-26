using SFML.System;
using SFML.Graphics;

namespace Game.Units
{
    class Basket : Actor
    {
        public RectangleShape BorderRight;
        public RectangleShape BorderLeft;

        public Basket()
        {
            BorderLeft = InitBorder(new Vector2f(1f, 250f), new Vector2f(1350f, 300f), Color.Red);
            BorderRight = InitBorder(new Vector2f(1f, 250f), new Vector2f(1590f, 300f), Color.Red);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(form, states);
            target.Draw(BorderLeft, states);
            target.Draw(BorderRight, states);
        }

        private RectangleShape InitBorder(Vector2f size, Vector2f position, Color color)
        {
            RectangleShape border = new RectangleShape(size);
            border.FillColor = color;
            border.Position = position;
            return border;
        }
    }
}
