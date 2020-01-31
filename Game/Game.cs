using SFML.System;
using SFML.Graphics;
using Game.Core;
using Game.UI;
using Game.Units;
using Game.Factory;

namespace Game
{
    public class Game:GameLoop
    {
        public const uint DEFAULT_WINDOW_WIDTH = 1600;
        public const uint DEFAULT_WINDOW_HEIGHT = 900;
        public const string WINDOW_TITLE = "Basketball Game!";

        public Ball ball;

        private TextActor _textScore;
        private Basket _basket;
        private int _scoreAmount = 0;
        private bool _isCursorInsideBall = false;

        public Game() : base(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, Color.Black)
        {
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

            if (inputManager.WasPressed && ball.IsPointInside(inputManager.MousePos)) 
                ball.Hit(inputManager.MousePos);

            bool isInsideNow = ball.form.Position.X > _basket.BorderLeft.Position.X
                && ball.form.Position.X < _basket.BorderRight.Position.X
                && ball.form.Position.Y < _basket.BorderRight.Position.Y
                && ball.GetVelocity().Y > 0;
            ///TODO: Сделать базовую физику(интерфейс: если два объекта взаимодействуют, то AddForce)
            bool isScored = isInsideNow && !_isCursorInsideBall;
            _isCursorInsideBall = isInsideNow;

            if (isScored)
            {
                _textScore.textString = $"SCORE: {++_scoreAmount}";
            }
        }

        public override void CheckForCollide()
        {

        }

        private void InitScoretext()
        {
            _textScore = this.CreateText(new Text($"SCORE: {_scoreAmount}", new Font(TextFontDir.DefaultFont), 20),
                new Vector2f(4f, 8f), Color.Red);
        }

        private void InitBackground()
        {
            Actor _background = this.CreateActor<Actor>(new RectangleShape(new Vector2f(1600f, 900f)),
                new IntRect(0, 0, 2000, 1500), new Texture(ObjectsTextureDir.BackgroundDir));
        }

        private void InitBasket()
        {
            _basket = this.CreateActor<Basket>(new RectangleShape(new Vector2f(250f, 250f)),
                new IntRect(0, 0, 640, 463),new Texture(ObjectsTextureDir.BasketDir), new Vector2f(1350f, 300f));
        }

        private void InitBall()
        {
            ball = this.CreateActor<Ball>(new CircleShape(100),
                new IntRect(0, 0, 1979, 1974), new Texture(ObjectsTextureDir.BallDir), new Vector2f(800f, 450f));
        }
    }
}
