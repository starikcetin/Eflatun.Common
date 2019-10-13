using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Eflatun.Common
{
    /// <summary>
    /// Utilities and extension methods for <see cref="GameObject"/>s.
    /// </summary>
    public static class GameObjectUtils
    {
        /// <summary>
        /// Sets the active state of this <paramref name="gameObject"/> and it's first level parent.
        /// </summary>
        public static void SetActiveWithParent(this GameObject gameObject, bool value)
        {
            gameObject.SetActive(value);
            gameObject.transform.parent.gameObject.SetActive(value);
        }

        /// <summary>
        /// Sets the active state of this <paramref name="gameObject"/> and it's first level children.
        /// </summary>
        public static void SetActiveWithChildren(this GameObject gameObject, bool value)
        {
            gameObject.SetActive(value);
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(value);
            }
        }

        /// <summary>
        /// Sets the active state of this <paramref name="gameObject"/> and all of ancestors (parent, grandparent, parent of grandparent... etc).
        /// </summary>
        /// <remarks>
        /// This method loops through the hierarchy, thus eliminating recursive calls.
        /// </remarks>
        public static void SetActiveWithAncestors(this GameObject gameObject, bool value)
        {
            var t = gameObject.transform;
            while (t != null)
            {
                t.gameObject.SetActive(value);
                t = t.parent;
            }
        }

        /// <summary>
        /// Sets the active state of this <paramref name="gameObject"/> and all of it's children hierarchy (children, grandchildren, children of grandchildren... etc).
        /// </summary>
        /// <remarks>
        /// This method keeps a list of all children hierarchy as it loops through, thus eliminating recursive calls.
        /// </remarks>
        public static void SetActiveWithDescendants(this GameObject gameObject, bool value)
        {
            Transform firstLevel = SetActiveTSCH(gameObject.transform, value);
            if (firstLevel.childCount == 0) return;

            var queue = new List<Transform> {firstLevel};
            while (queue.Count > 0)
            {
                for (int i = queue.Count - 1; i >= 0; i--)
                {
                    Transform t = SetActiveTSCH(queue[i], value);
                    queue.RemoveAt(i);

                    if (t.childCount > 0) queue.AddRange(t.Cast<Transform>());
                }
            }
        }

        /// <summary>
        /// SetActive Through Single Child Hierarchy <para/>
        /// 'SetActive's transform; if transform has only one child, switches to child; repeats the process. <para/>
        /// Continues until switching to a transform with no child or more than one child. <para/>
        /// Returns the transform it stopped.
        /// </summary>
        private static Transform SetActiveTSCH(Transform beginWith, bool value)
        {
            Transform t = beginWith;
            t.gameObject.SetActive(value);

            while (t.childCount == 1)
            {
                t = t.GetChild(0);
                t.gameObject.SetActive(value);
            }

            return t;
        }
    }
}
