//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Arrays
    {
        /// <summary>
        /// Fills an array, in-place, with a specified value
        /// </summary>
        /// <param name="dst">The target array</param>
        /// <param name="dst">The source value</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] fill<T>(T[] dst, T src)
        {
            Array.Fill(dst, src);
            return dst;
        }
    }
}
