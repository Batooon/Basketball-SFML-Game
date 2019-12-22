using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;

namespace Game
{
    public abstract class GameLoop
    {
        public const int TARGET_FPS = 120;
        public const float TIME_UNTIL_UPDATE = 1f / TARGET_FPS;

        public RenderWindow Window
        {
            get;
            protected set;
        }

        public GameTime GameTime
        {
            get;
            protected set;
        }

        public Color WindowClearColor
        {
            get;
            protected set;
        }

        protected GameLoop(uint windowWidth, uint windowHeight,string windowTitle, Color windowClearColor)
        {
            WindowClearColor = windowClearColor;
            Window = new RenderWindow(new VideoMode(windowWidth, windowHeight), windowTitle);
            GameTime = new GameTime();

            Window.Closed += WindowClosed;
        }

        public void Run()
        {
            LoadContent();
            Initialize();

            float totalTimeBeforeUpdate = 0f;
            float previousTimeElapsed = 0f;
            float deltaTime = 0f;
            float totalTimeElapsed = 0f;

            Clock clock = new Clock();

            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;

                totalTimeBeforeUpdate += deltaTime;

                if (totalTimeBeforeUpdate >= TIME_UNTIL_UPDATE)
                {
                    GameTime.Update(totalTimeBeforeUpdate, clock.ElapsedTime.AsSeconds());
                    totalTimeBeforeUpdate = 0f;

                    Update(GameTime);

                    Window.Clear(WindowClearColor);
                    Draw(GameTime);
                    Window.Display();
                }
            }
        }

        void WindowClosed(object sender, EventArgs e)
        {
            Window.Close();
        }

        public abstract void LoadContent();
        public abstract void Initialize();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
