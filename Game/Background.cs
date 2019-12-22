using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Game
{
    class Background : Transformable, Drawable
    {
        const string DIR = "..\\Content\\Textures\\background.jpg";

        public Texture texture;
        RectangleShape bg;

        public void LoadContent()
        {
            texture = new Texture(DIR);
        }

        public void Display(GameLoop gameLoop)
        {
            bg = new RectangleShape(new Vector2f(1600f, 900f));

            bg.Texture = texture;
            bg.TextureRect = new IntRect(0, 0, 2000, 1500);

            gameLoop.Window.Draw(this);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(bg, states);
        }
    }
}
