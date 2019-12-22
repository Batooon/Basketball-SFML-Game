using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

/*
 * GAME LOOP:
 * 1. Load Content
 * 2. Initialize
 * 3. Update Game Logic<---|      |For example at 60 fps
 * 4. Render >-------------|      |
*/
/*
 * DELTA TIME -------> at 60 fps - 1/60=0,01(6)
 * Time that elapsed between the previous frame and the current frame
 * Makes t5he Game framerate-independent
*/

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
        }

        /*static RenderWindow win;
        public static Game Game { private set; get; }
        public static RenderWindow Window { get { return win; } }

        static void Main(string[] args)
        {
            win = new RenderWindow(new SFML.Window.VideoMode(1600, 900), "Basketball");
            win.SetVerticalSyncEnabled(true);

            win.Closed += Win_Closed;

            //Load content and Init
            Game = new Game();

            //Game Loop
            while (win.IsOpen)
            {
                //Update Game Logic
                win.DispatchEvents();

                Game.Update();

                win.Clear(Color.Black);

                //Draw
                Game.Draw();

                win.Display();
            }
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            win.Close();
        }*/
    }
}
