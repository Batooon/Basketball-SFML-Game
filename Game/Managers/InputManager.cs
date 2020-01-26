using SFML.System;
using SFML.Window;

namespace Game.Managers
{
    public class InputManager
    {
        public bool WasPressed
        {
            get;
            private set;
        }

        public Vector2i MousePos
        {
            get;
            private set;
        }

        public void RefreshInput(ref bool isEndGame)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                isEndGame = true;

            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (WasPressed)
                    return;

                WasPressed = true;

                MousePos = Mouse.GetPosition();
            }
            else
                WasPressed = false;
        }
    }
}
