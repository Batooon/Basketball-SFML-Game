using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Game
{
    class Basket:Transformable,Drawable
    {
        const string DIR = "..\\Content\\Textures\\basket.png";

        public Texture texture;
        RectangleShape basket;

        public void LoadContent()
        {
            texture = new Texture(DIR);
        }

        public void Display(GameLoop gameLoop)
        {
            basket = new RectangleShape(new Vector2f(250f, 250f));

            basket.Texture = texture;
            basket.TextureRect = new IntRect(0, 0, 640, 463);
            basket.Position = new Vector2f(1350f, 300f);

            gameLoop.Window.Draw(this);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(basket, states);
        }
    }
}
