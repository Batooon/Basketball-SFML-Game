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

        protected List<IUpdatable> UpdatableObjects;

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
            Window = new RenderWindow(new VideoMode(windowWidth, windowHeight), windowTitle, Styles.Default);
            Window.SetVerticalSyncEnabled(true);
            GameTime = new GameTime();

            Window.Closed += WindowClosed;

            UpdatableObjects = new List<IUpdatable>();
        }

        protected bool isEndGame = false;
        public virtual bool IsEndGameLoop()
            => !Window.IsOpen || isEndGame;

        public void Run()
        {
            LoadContent();
            Initialize();

            float totalTimeBeforeUpdate = 0f;
            float previousTimeElapsed = 0f;
            float deltaTime = 0f;
            float totalTimeElapsed = 0f;

            Clock clock = new Clock();

            while (!IsEndGameLoop())
            {
                Window.DispatchEvents();

                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;

                totalTimeBeforeUpdate += deltaTime;

                GetInput();

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

        public virtual void LoadContent() { }
        public virtual void Initialize() { }
        public virtual void Update(GameTime gameTime) 
        {
            foreach (IUpdatable u in UpdatableObjects)
                u.Update(gameTime.DeltaTime);
        }
        public virtual void Draw(GameTime gameTime) { }
        public virtual void GetInput() { }
    }
}
