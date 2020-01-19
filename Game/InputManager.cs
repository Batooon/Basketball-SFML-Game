using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;

namespace Game
{
    public class InputManager
    {
        public bool wasPressed = false;
        public Vector2i mousePos = new Vector2i();

        public void RefreshInput(ref bool isEndGame)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                isEndGame = true;

            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (wasPressed)
                    return;

                wasPressed = true;

                mousePos = Mouse.GetPosition();
            }
            else
                wasPressed = false;
        }
    }
}
