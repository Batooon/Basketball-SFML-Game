using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace Game
{
    class Basket : Actor
    {
        public RectangleShape borderRight;
        public RectangleShape borderLeft;


        public Basket(ActorArgs args) : base(args)
        {
            borderLeft = InitBorder(new Vector2f(1f, 250f), new Vector2f(1350f, 300f), Color.Red);
            borderRight = InitBorder(new Vector2f(1f, 250f), new Vector2f(1590f, 300f), Color.Red);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(form, states);
            target.Draw(borderLeft, states);
            target.Draw(borderRight, states);
        }

        RectangleShape InitBorder(Vector2f size, Vector2f position, Color color)
        {
            RectangleShape border = new RectangleShape(size);
            border.FillColor = color;
            border.Position = position;
            return border;
        }
    }
}
