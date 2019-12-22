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

        public Game() : base(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, Color.Black)
        {
            score = new ScoreText();
        }

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            score.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(GameTime gameTime)
        {
            score.DisplayPerformanceData(this, Color.White);
        }

        /*World world;
        public Game()
        {
            world = new World();
        }

        public void Update()
        {

        }

        public void Draw()
        {
            Program.Window.Draw(world);
        }*/
    }
}
