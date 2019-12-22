using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Game
{
    public class ScoreText
    {
        public const string CONSOLE_FONT_PATH = "./Fonts/Alatsi-Regular.ttf";

        public Font consoleFont;

        public void LoadContent()
        {
            consoleFont = new Font(CONSOLE_FONT_PATH);
        }

        public void DisplayPerformanceData(GameLoop gameLoop, Color fontColor)
        {
            if (consoleFont == null)
                return;

            string totalTimeElapsedText = gameLoop.GameTime.TotalTimeElapsed.ToString("0.000");
            string deltaTime = gameLoop.GameTime.DeltaTime.ToString("0.000");
            float fps = 1f / gameLoop.GameTime.DeltaTime;
            string fpsStr = fps.ToString("0.00");

            Text text = new Text(totalTimeElapsedText, consoleFont, 14);
            text.Position = new Vector2f(4f, 8f);
            text.Color = fontColor;

            Text textb = new Text(deltaTime, consoleFont, 14);
            textb.Position = new Vector2f(4f, 28f);
            textb.Color = fontColor;

            Text textc = new Text(fpsStr, consoleFont, 14);
            textc.Position = new Vector2f(4f, 48f);
            textc.Color = fontColor;

            gameLoop.Window.Draw(text);
            gameLoop.Window.Draw(textb);
            gameLoop.Window.Draw(textc);
        }
    }
}
