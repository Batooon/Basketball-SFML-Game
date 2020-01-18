using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace Game
{
    public class ActorFabrik
    {
        public Actor CreateActor(ActorType objectType, Shape shape, IntRect rect, Vector2f position = new Vector2f())
        {
            ActorArgs args;
            args.actorType = objectType;
            args.Position = position;
            args.Rect = rect;
            args.Shape = shape;

            switch (objectType)
            {
                case ActorType.Ball:
                    return new Ball(args);
                case ActorType.Basket:
                    return new Basket(args);
                default:
                    return new Actor(args);
            }
        }
    }
}
