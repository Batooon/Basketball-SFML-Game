using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Audio;
using SFML.Window;

namespace Game
{
    public class GameTime
    {
        private float deltaTime = 0f;
        private float timeScale = 1f;

        public float TimeScale
        {
            get { return timeScale; }
            set { timeScale = value; }
        }

        public float DeltaTime
        {
            get { return deltaTime * timeScale; }
            set { deltaTime = value; }
        }

        public float DceltaTimeUnscaled
        {
            get { return deltaTime; }
        }

        public float TotalTimeElapsed
        {
            get;
            private set;
        }

        public GameTime()
        {
        }

        public void Update(float deltaTime, float totalTimeElapsed)
        {
            this.deltaTime = deltaTime;
            TotalTimeElapsed = totalTimeElapsed;
        }
    }
}
