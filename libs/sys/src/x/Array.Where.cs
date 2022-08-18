//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Linq where operator specialized for arrays
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="f"></param>
        /// <typeparam name="T">The array element type</typeparam>
        [MethodImpl(Inline)]
        public static T[] Where<T>(this T[] src, Func<T,bool> f)
            => sys.where(src,f).ToArray();
    }
}