using Game.Core;
using SFML.Graphics;
using SFML.System;
using Game.Interfaces;
namespace Game.UI
{
    public static class TextFontDir
    {
        public static string DefaultFont = "./Fonts/Alatsi-Regular.ttf";
    }

    public struct TextActorArgs
    {
        public Vector2f TextPosition;
        public Color TextColor;
        public Text text;
    }

    public class TextActor : IDrawable
    {
        public string textString;
        public Font font;
        public Text text;

        private uint characterSize;
        private Color color;

        public TextActor()
        {

        }

        public void PostCreate(TextActorArgs args)
        {
            color = args.TextColor;
            font = args.text.Font;
            text = args.text;

            text.Position = args.TextPosition;
            text.FillColor = args.TextColor;
            text.Font = font;

            textString = args.text.DisplayedString;
            characterSize = args.text.CharacterSize;
        }

        public void Display(GameLoop gameLoop)
        {
            if (text == null)
                return;

            text = new Text(textString, font, characterSize);
            text.FillColor = color;

            gameLoop.Window.Draw(text);
        }
    }
}
