using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Game
{
    class Program
    {
        static RenderWindow win;
        public static Game Game { private set; get; }
        public static RenderWindow Window { get { return win; } }

        static void Main(string[] args)
        {
            win = new RenderWindow(new SFML.Window.VideoMode(1600, 900), "Basketball");
            win.SetVerticalSyncEnabled(true);

            win.Closed += Win_Closed;

            //Загрузка контента

            Game = new Game();

            while (win.IsOpen)
            {
                win.DispatchEvents();

                Game.Update();

                win.Clear(Color.Black);

                //отрисовка
                Game.Draw();

                win.Display();
            }
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            win.Close();
        }
    }
}
