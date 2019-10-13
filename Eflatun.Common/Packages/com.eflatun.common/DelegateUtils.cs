using System;

namespace Eflatun.Common
{
    //
    // These were written back in the day when Unity did not support the null-conditional operators.
    // Now Unity supports them, so you can simple do this instead:
    //     delegate?.Invoke()
    // But I am keeping these in case someone uses this library in an older Unity version.
    //

    /// <summary>
    /// Utilities for delegate types.
    /// </summary>
    public static class DelegateUtils
    {
        /// <summary>
        /// Invokes the <paramref name="action"/> if it is not null.
        /// </summary>
        public static void InvokeSafe(this Action action)
        {
            if (action != null) action.Invoke();
        }

        /// <summary>
        /// Invokes the <paramref name="action"/> if it is not null.
        /// </summary>
        public static void InvokeSafe<T>(this Action<T> action, T param)
        {
            if (action != null) action.Invoke(param);
        }

        /// <summary>
        /// Invokes the <paramref name="action"/> if it is not null.
        /// </summary>
        public static void InvokeSafe<T1, T2>(this Action<T1, T2> action, T1 param1, T2 param2)
        {
            if (action != null) action.Invoke(param1, param2);
        }

        /// <summary>
        /// Invokes the <paramref name="action"/> if it is not null.
        /// </summary>
        public static void InvokeSafe<T1, T2, T3>(this Action<T1, T2, T3> action, T1 param1, T2 param2, T3 param3)
        {
            if (action != null) action.Invoke(param1, param2, param3);
        }
    }
}
