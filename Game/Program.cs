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

        static void Main(string[] args)
        {
            win = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Basketball");
            win.SetVerticalSyncEnabled(true);

            win.Closed += Win_Closed;

            //Загрузка контентаdsw
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            win.Close();
        }
    }
}
