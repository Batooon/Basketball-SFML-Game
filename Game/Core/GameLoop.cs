using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Game.Interfaces;
using Game.Managers;

namespace Game.Core
{
    public abstract class GameLoop
    {
        public const int TARGET_FPS = 120;
        public const float TIME_UNTIL_UPDATE = 1f / TARGET_FPS;

        public InputManager inputManager = new InputManager();
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

        protected List<IUpdatable> UpdatableObjects;
        protected List<IDrawable> DrawableObjects;
        protected bool isEndGame = false;

        protected GameLoop(uint windowWidth, uint windowHeight, string windowTitle, Color windowClearColor)
        {
            WindowClearColor = windowClearColor;
            Window = new RenderWindow(new VideoMode(windowWidth, windowHeight), windowTitle, Styles.Default);
            Window.SetVerticalSyncEnabled(true);
            GameTime = new GameTime();

            Window.Closed += WindowClosed;

            UpdatableObjects = new List<IUpdatable>();
            DrawableObjects = new List<IDrawable>();
        }

        public void RegisterDrawableActor(IDrawable drawable)
        {
            if (!DrawableObjects.Contains(drawable))
            DrawableObjects.Add(drawable);
        }

        public void RegisterActor(IUpdatable actor)
        {
            if (!UpdatableObjects.Contains(actor))
                UpdatableObjects.Add(actor as IUpdatable);
        }

        public void UnregisterActor(IUpdatable actor)
        {
            if (UpdatableObjects.Contains(actor))
                UpdatableObjects.Remove(actor);
        }

        public void UnregisterDrawableActor(IDrawable drawable)
        {
            if (DrawableObjects.Contains(drawable))
                DrawableObjects.Remove(drawable);
        }

        public virtual bool IsEndGameLoop()
            => !Window.IsOpen || isEndGame;

        public void Run()
        {
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

        public virtual void LoadContent() { }
        public virtual void Initialize() { }
        public virtual void Update(GameTime gameTime)
        {
            foreach (IUpdatable u in UpdatableObjects)
                u.Update(gameTime.DeltaTime);
        }
        public virtual void Draw(GameTime gameTime)
        {
            foreach (IDrawable drawableObject in DrawableObjects)
                drawableObject.Display(this);
        }

        public virtual void GetInput() { inputManager.RefreshInput(ref isEndGame); }

        private void WindowClosed(object sender, EventArgs e)
        {
            Window.Close();
            Window.Closed -= WindowClosed;
            RemoveAllUpdatableObjects();
            RemoveAllDrawableObjects();
        }

        private void RemoveAllDrawableObjects()
        {
            for (int i = 0; i < DrawableObjects.Count; i++)
            {
                UnregisterDrawableActor(DrawableObjects[i]);
            }
        }

        private void RemoveAllUpdatableObjects()
        {
            for (int i = 0; i < UpdatableObjects.Count; i++)
            {
                UnregisterActor(UpdatableObjects[i]);
            }
        }
    }
}
