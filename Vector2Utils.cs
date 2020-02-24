using UnityEngine;

namespace Eflatun.Common
{
    public static class Vector2Utils
    {
        public static void Deconstruct(this Vector2 v2, out float x, out float y)
        {
            x = v2.x;
            y = v2.y;
        }
    }
}
