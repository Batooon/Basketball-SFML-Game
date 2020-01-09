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
        public static TextActorArgs Text(FontDir font, string text, uint characterSize, Vector2f position, Color color)
        {
            TextActorArgs actor;

            actor.FontPath = font;
            actor.Text = text;
            actor.CharacterSize = characterSize;
            actor.TextPosition = position;
            actor.TextColor = color;

            return actor;
        }

    }
}
