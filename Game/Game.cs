using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using SFML.Audio;

namespace Game
{
    public class Game:GameLoop
    {
        public const uint DEFAULT_WINDOW_WIDTH = 1600;
        public const uint DEFAULT_WINDOW_HEIGHT = 900;

        public const string WINDOW_TITLE = "Basketball Game!";
        ScoreText score;
        Ball ball;
        Background background;
        Basket basket;

        public Game() : base(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, Color.Black)
        {
            score = new ScoreText();
            ball = new Ball();
            background = new Background();
            basket = new Basket();
        }

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            background.LoadContent();
            score.LoadContent();
            ball.LoadContent();
            basket.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(GameTime gameTime)
        {
            background.Display(this);
            ball.DisplayBall(this);
            basket.Display(this);
            score.DisplayPerformanceData(this, Color.White);
        }
    }
}
