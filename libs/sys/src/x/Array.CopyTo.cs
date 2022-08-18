//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Copies a source list to a target array
        /// </summary>
        /// <param name="src">The list containing the elements to copy</param>
        /// <param name="dst">The array that will receive the copied elements</param>
        /// <typeparam name="T">The element type</typeparam>
        public static int CopyTo<T>(this T[] src, T[] dst)
            => sys.copy(src,dst);
    }
}