
namespace Game.Core
{
    public class GameTime
    {
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

        private float deltaTime = 0f;
        private float timeScale = 1f;

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
