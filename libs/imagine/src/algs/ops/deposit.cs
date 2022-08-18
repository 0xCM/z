//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline), Closures(Closure)]
        public static void deposit<T>(ReadOnlySpan<T> src, HashSet<T> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                dst.Add(sys.skip(src,i));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void deposit<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, HashSet<T> dst)
        {
            var kA = a.Length;
            for(var i=0; i<kA; i++)
                dst.Add(sys.skip(a,i));

            var kB = b.Length;
            for(var i=0; i<kB; i++)
                dst.Add(sys.skip(b,i));
        }
    }
}