using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Game
{
    public class TextFabrik
    {
        public TextActor Create(FontDir font, string text, uint characterSize, Vector2f position, Color color)
        {
            TextActorArgs args;

            args.FontPath = font;
            args.Text = text;
            args.CharacterSize = characterSize;
            args.TextPosition = position;
            args.TextColor = color;

            return new TextActor(args);
        }

    }
}
