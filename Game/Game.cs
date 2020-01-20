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

        TextActor text;
        public Ball ball;
        Actor background;
        Basket basket;

        int score = 0;
        bool isInside = false;

        public Game() : base(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, Color.Black)
        {
        }

        private void InitScoretext()
        {
            text = this.CreateText(new Text($"SCORE: {score}", new Font(TextFontDir.DefaultFont), 20),
                new Vector2f(4f, 8f), Color.Red);
        }

        private void InitBackground()
        {
            background = this.CreateActor<Actor>(new RectangleShape(new Vector2f(1600f, 900f)),
                new IntRect(0, 0, 2000, 1500), new Texture(ObjectsTextureDir.BackgroundDir));
        }

        private void InitBasket()
        {
            basket = this.CreateActor<Basket>(new RectangleShape(new Vector2f(250f, 250f)),
                new IntRect(0, 0, 640, 463),new Texture(ObjectsTextureDir.BasketDir), new Vector2f(1350f, 300f));
        }

        private void InitBall()
        {
            ball = this.CreateActor<Ball>(new CircleShape(100),
                new IntRect(0, 0, 1979, 1974), new Texture(ObjectsTextureDir.BallDir), new Vector2f(800f, 450f));
        }
    
        public override void Initialize()
        {
            //Важно соблюдать порядок(бэкграунд может перекрыть остальные объекты)
            InitBackground();
            InitBall();
            InitBasket();
            InitScoretext();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (ball.IsPointInside(inputManager.mousePos) && inputManager.wasPressed)
                ball.Hit(inputManager.mousePos);

            bool isInsideNow = ball.form.Position.X > basket.borderLeft.Position.X
                && ball.form.Position.X < basket.borderRight.Position.X
                && ball.form.Position.Y < basket.borderRight.Position.Y
                && ball.get_velocity().Y > 0;
            ///TODO: Сделать базовую физику(интерфейс: если два объекта взаимодействуют, то AddForce)
            bool isScored = isInsideNow && !isInside;
            isInside = isInsideNow;

            if (isScored)
            {
                text.textString = $"SCORE: {++score}";
            }
        }
    }
}
