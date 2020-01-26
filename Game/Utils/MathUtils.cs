using System;
using SFML.System;

namespace Game.Utils
{
    internal static class MathUtils
    {
        public static float DistanceTo(this Vector2i origin, Vector2i destination)
        {
            return ((Vector2f)origin).DistanceTo((Vector2f)destination);
        }
        public static float DistanceTo(this Vector2i origin, Vector2f destination)
        {
            return ((Vector2f)origin).DistanceTo(destination);
        }
        public static float DistanceTo(this Vector2f origin, Vector2i destination)
        {
            return origin.DistanceTo((Vector2f)destination);
        }
        public static float DistanceTo(this Vector2f origin, Vector2f destination)
        {
            float dx = destination.X - origin.X;
            float dy = destination.Y - origin.Y;
            double length = Math.Sqrt(dx * dx + dy * dy);
            return (float)length;
        }
    }
}
