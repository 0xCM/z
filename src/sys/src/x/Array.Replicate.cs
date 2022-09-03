//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Allocates an populates a new array that is identical to the source array
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The element type</typeparam>
        public static T[] Replicate<T>(this T[] src)
        {
            var dst = new T[src.Length];
            System.Array.Copy(src, dst, src.Length);
            return dst;
        }
    }
}