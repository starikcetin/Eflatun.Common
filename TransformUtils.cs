using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Eflatun.Common
{
    /// <summary>
    /// Utilities and extension methods for <see cref="Transform"/>s.
    /// </summary>
    public static class TransformUtils
    {
        /// <summary>
        /// Returns all children of <paramref name="transform"/>
        /// </summary>
        public static IEnumerable<Transform> GetChildren(this Transform transform)
        {
            return transform.Cast<Transform>();
        }

        /// <summary>
        /// Returns the 2D position of given transform on XY plane. Uses manual conversion.
        /// </summary>
        public static Vector2 Position2D(this Transform transform)
        {
            var p = transform.position;
            return new Vector2(p.x, p.y);
        }

        /// <summary>
        /// Returns the 2D local position of given transform on XY plane. Uses manual conversion.
        /// </summary>
        public static Vector2 LocalPosition2D(this Transform transform)
        {
            var lp = transform.localPosition;
            return new Vector2(lp.x, lp.y);
        }

        /// <summary>
        /// Moves the transform to a Vector2 on XY coordinates.
        /// </summary>
        public static void SetPosition2D(this Transform transform, Vector2 newPosition)
        {
            transform.position = new Vector3(newPosition.x, newPosition.y, 0);
        }

        /// <summary>
        /// Moves the transform to a Vector2 on local XY coordinates.
        /// </summary>
        public static void SetLocalPosition2D(this Transform transform, Vector2 newLocalPosition)
        {
            transform.localPosition = new Vector3(newLocalPosition.x, newLocalPosition.y, 0);
        }
    }
}
