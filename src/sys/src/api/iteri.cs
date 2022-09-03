//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Appplies an action for each element in a source span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="f">The receiver</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iteri<T>(ReadOnlySpan<T> src, Action<int,T> f)
        {
            for(var i=0; i<src.Length; i++)
                f(i, skip(src,i));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iteri<T>(Span<T> src, Action<int,T> f)
            => iteri(@readonly(src),f);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iteri<T>(T[] src, Action<int,T> f)
            => iteri(@readonly(src),f);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iteri<T>(Index<T> src, Action<int,T> f)
            => iteri(src.View,f);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iteri<T>(Seq<T> src, Action<int,T> f)
            => iteri(src.View,f);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iteri<T>(ReadOnlySeq<T> src, Action<int,T> f)
            => iteri(src.View,f);
    }
}