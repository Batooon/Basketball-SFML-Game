using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace Game
{
    public static class ActorFabrik
    {
        public static T CreateActor<T>(this Game game, ActorType objectType, Shape shape, IntRect rect, Texture texture, Vector2f position = new Vector2f()) where T:Actor,new()
        {
            ActorArgs args;
            args.actorType = objectType;
            args.Position = position;
            args.Rect = rect;
            args.Shape = shape;
            args.texture = texture;
            T t = new T();
            t.PostCreate(args);
            return t;
        }
    }
}
