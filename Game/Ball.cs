using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Ball
    {
        const string CONTENT_DIR = "..\\Content\\";

        public Texture ballTexture;

        public Ball()
        {
            ballTexture = new Texture(CONTENT_DIR + "ball.png");
        }
    }
}
