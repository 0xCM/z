//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Fills an array with the element type's default value
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The array element type</typeparam>
        [MethodImpl(Inline)]
        public static T[] Clear<T>(this T[] src)
            where T : struct
                => sys.clear(src);
    }
}