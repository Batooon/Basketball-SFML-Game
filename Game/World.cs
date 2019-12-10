using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class World : Transformable,Drawable
    {
        Ball ball;
        public World()
        {
            ball = new Ball();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(ball, states);
        }
    }
}
