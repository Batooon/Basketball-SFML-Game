using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Game
{
    public interface IDrawable
    {
        void Display(GameLoop gameLoop);
    }
}
