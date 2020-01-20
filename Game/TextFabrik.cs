using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Game
{
    public static class TextFabrik
    {
        public static TextActor CreateText(this GameLoop gameLoop, Text txt, Vector2f position, Color color)
        {
            TextActor t = CreateText_Internal(txt, position, color);
            if (t == null)
                return null;

            RegisterText(gameLoop, t);
            return t;
        }

        private static TextActor CreateText_Internal(Text txt, Vector2f position, Color color)
        {
            TextActorArgs args;

            args.TextPosition = position;
            args.TextColor = color;
            args.text = txt;
            TextActor t = new TextActor();
            t.PostCreate(args);

            return t;
        }

        private static void RegisterText(GameLoop game, TextActor t)
        {
            game.RegisterDrawableActor(t);
        }
    }
}
