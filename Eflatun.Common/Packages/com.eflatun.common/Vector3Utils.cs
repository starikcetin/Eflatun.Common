using UnityEngine;

namespace Eflatun.Common
{
    public static class Vector3Utils
    {
        public static void Deconstruct(this Vector3 v3, out float x, out float y, out float z)
        {
            x = v3.x;
            y = v3.y;
            z = v3.z;
        }
    }
}
