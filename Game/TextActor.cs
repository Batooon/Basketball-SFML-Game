using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Game
{
    public enum FontDir
    {
        Default
    }

    public struct TextActorArgs
    {
        public FontDir FontPath;
        public string Text;
        public uint CharacterSize;
        public Vector2f TextPosition;
        public Color TextColor;
    }

    class TextActor
    {
        string DefaultFontDir = "./Fonts/Alatsi-Regular.ttf";
        public Font font;
        TextActorArgs textArgs;

        Text text;

        public TextActor(TextActorArgs args)
        {
            switch (args.FontPath)
            {
                case FontDir.Default:
                    font = new Font(DefaultFontDir);
                    break;
                default:
                    throw new NotSupportedException("This font direction is incorrect");
            }
            textArgs = args;

            if (font == null)
                return;

            text = new Text(textArgs.Text, font, textArgs.CharacterSize);
            text.Position = textArgs.TextPosition;
            text.FillColor = textArgs.TextColor;
        }

        public void Display(GameLoop gameLoop)
        {
            if (text == null)
                return;

            gameLoop.Window.Draw(text);
        }
    }
}
