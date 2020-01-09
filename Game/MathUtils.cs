using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Game
{
    internal static class MathUtils
    {
        public static float DistanceTo(this Vector2i origin, Vector2i destination)
        {
            return DistanceTo((Vector2f)origin, (Vector2f)destination);
        }
        public static float DistanceTo(this Vector2i origin, Vector2f destination)
        {
            return DistanceTo((Vector2f)origin, destination);
        }
        public static float DistanceTo(this Vector2f origin, Vector2i destination)
        {
            return DistanceTo(origin, (Vector2f)destination);
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
