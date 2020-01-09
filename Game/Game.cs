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
        Actor basket;

        public Game() : base(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, Color.Black)
        {
            InitBall();
            InitBackground();
            InitBasket();
            InitScoretext();
            UpdatableObjects.Add(ball);
        }

        private void InitScoretext()
        {
            text = new TextActor(TextFabrik.Text(FontDir.Default, "Score",
                20, new Vector2f(4f, 8f), Color.Red));
        }

        private void InitBackground()
        {
            background = new Actor(ActorFabrik.CreateActorArgs(ActorType.Background,
                new RectangleShape(new Vector2f(1600f, 900f)), new IntRect(0, 0, 2000, 1500)));
        }

        private void InitBasket()
        {
            basket = new Actor(ActorFabrik.CreateActorArgs(ActorType.Basket,
                new RectangleShape(new Vector2f(250f, 250f)), new IntRect(0, 0, 640, 463), new Vector2f(1350f, 300f)));
        }

        private void InitBall()
        {
            ball = new Ball(ActorFabrik.CreateActorArgs(ActorType.Ball,
                new CircleShape(100), new IntRect(0, 0, 1979, 1974), new Vector2f(800f, 450f)));
        }

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            background.Display(this);
            ball.Display(this);
            basket.Display(this);
            text.Display(this);
        }


#region FuckingKostyl
        bool wasPressed = false;
        public override void GetInput()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                isEndGame = true;

            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (wasPressed)
                    return;
                wasPressed = true;

                if (ball == null)
                    return;

                Vector2i MousePos = Mouse.GetPosition();
                if (ball.IsPointInside(MousePos))
                    ball.Hit(MousePos);
            }
            else
            {
                wasPressed = false;
            }
        }
#endregion
    }
}
