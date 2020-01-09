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

    public enum ActorType
    {
        Ball,
        Background,
        Basket
    }

    public struct ActorArgs
    {
        public ActorType actorType;
        public Shape Shape;
        public IntRect Rect;
        public Vector2f Position;
    }

    public class Actor : Transformable, Drawable
    {
        public Texture texture;
        public Shape form;
        
        public Actor(ActorArgs args)
        {
            switch (args.actorType)
            {
                case ActorType.Ball:
                    texture = new Texture(ObjectsTextureDir.BallDir);
                    break;
                case ActorType.Background:
                    texture = new Texture(ObjectsTextureDir.BackgroundDir);
                    break;
                case ActorType.Basket:
                    texture = new Texture(ObjectsTextureDir.BasketDir);
                    break;
                default:
                    throw new NotSupportedException("This type of object does not exist");
            }
            form = args.Shape;
            form.Position = args.Position;
            form.Texture = texture;
            form.TextureRect = args.Rect;
        }

        public void Draw(RenderTarget target, RenderStates states)
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
