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
        public static ActorArgs CreateActorArgs(ActorType objectType, Shape shape, IntRect rect, Vector2f position = new Vector2f())
        {
            ActorArgs args;

            args.actorType = objectType;
            args.Shape = shape;
            args.Rect = rect;
            args.Position = position;

            return args;
        }
    }
}
