using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace Game
{
    public static class ObjectsTextureDir
    {
        public static string BallDir = "..\\Content\\Textures\\ball.png";
        public static string BasketDir = "..\\Content\\Textures\\basket.png";
        public static string BackgroundDir = "..\\Content\\Textures\\background.jpg";
    }

    public struct ActorArgs
    {
        public Shape Shape;
        public IntRect Rect;
        public Vector2f Position;
        public Texture texture;
    }

    public class Actor : Transformable, Drawable
    {
        Texture texture;
        public Shape form;

        public Actor()
        {

        }

        public void PostCreate(ActorArgs args)
        {
            texture = args.texture;
            form = args.Shape;
            form.Position = args.Position;
            form.Texture = texture;
            form.TextureRect = args.Rect;
        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(form, states);
        }

        public void Display(GameLoop gameLoop)
        {
            gameLoop.Window.Draw(this);
        }
    }
}
