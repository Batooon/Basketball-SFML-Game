using SFML.System;
using SFML.Graphics;
using Game.Core;
using Game.Interfaces;

namespace Game.Units
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

    public class Actor : Transformable, Drawable, IDrawable
    {
        public Shape form;

        private Texture texture;

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
