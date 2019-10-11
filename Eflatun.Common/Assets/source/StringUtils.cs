using System;
using UnityEngine;

namespace Eflatun.Common
{
    /// <summary>
    /// Provides utilities for strings.
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Casts <paramref name="input"/> to <typeparamref name="T"/> type. <para/>
        /// This method only supports primitive types and Enums.
        /// </summary>
        public static T Cast<T>(this string input)
        {
            var wantedType = typeof(T);

            if (wantedType.IsPrimitive)
            {
                // If the wanted type is Boolean but the input is in Integer form, we need to cast to Integer first.
                if (wantedType == typeof(bool))
                {
                    int intInput;
                    if (int.TryParse(input, out intInput))
                    {
                        return (T) Convert.ChangeType(intInput, wantedType);
                    }
                }

                return (T) Convert.ChangeType(input, wantedType);
            }
            else if (wantedType.IsEnum)
            {
                try
                {
                    return (T) Enum.Parse(wantedType, input);
                }
                catch
                {
                    // We cannot parse to wanted Enum directly, try to cast to Integer and get the value from array of values.
                    int intInput;
                    if (int.TryParse(input, out intInput))
                    {
                        Array allValues = Enum.GetValues(wantedType);

                        if (intInput < 0 || intInput > allValues.Length - 1)
                        {
                            throw new IndexOutOfRangeException(
                                "The 'input' is out of the range of the target enum's array of values.");
                        }

                        return (T) allValues.GetValue(intInput);
                    }

                    throw;
                }
            }

            throw new NotSupportedException("This method only supports primitive types and Enums.");
        }

        /// <summary>
        /// Casts <paramref name="input"/> to Static-Object-Enum <typeparamref name="T"/> type.
        /// </summary>
        public static T CastSOE<T>(this string input) where T : StaticObjectEnum<T>
        {
            try
            {
                return StaticObjectEnum<T>.Parse(input);
            }
            catch
            {
                // We cannot parse to wanted Static-Object-Enum directly, try to cast to Integer and get the value from list of instances.
                int intInput;
                if (int.TryParse(input, out intInput))
                {
                    if (intInput < 0 || intInput > StaticObjectEnum<T>.All.Count - 1)
                    {
                        throw new IndexOutOfRangeException(
                            "The 'input' is out of the range of the target Static-Object-Enum's list of instances.");
                    }

                    return StaticObjectEnum<T>.All[intInput];
                }

                throw;
            }
        }

        /// <summary>
        /// Returns a new string which is <paramref name="input"/> string wrapped with HTML color tags (in Unity format). <para/>
        /// This method does NOT change <paramref name="input"/>, it returns a new string instead.
        /// </summary>
        /// <remarks>
        /// The <see cref="Color"/>'s range is (0 - 1), but <see cref="ColorUtility.ToHtmlStringRGBA"/> converts it to (00 - ff) range.
        /// </remarks>
        public static string Colored(this string input, Color color)
        {
            return string.Format("<color=#{0}>{1}</color>", ColorUtility.ToHtmlStringRGBA(color), input);
        }

        /// <summary>
        /// Returns <c>true</c> if <paramref name="value"/> is <c>null</c> or and empty string; <c>false</c> otherwise.
        /// </summary>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
