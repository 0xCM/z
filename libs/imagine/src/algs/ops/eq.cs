//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool eq<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b)
            where T : IEquatable<T>
        {
            var count = a.Length;
            if(count != b.Length)
                return false;
            for(var i=0u; i<count; i++)
                if(!Spans.skip(a, i).Equals(Spans.skip(b, i)))
                    return false;
            return true;
        }

        [MethodImpl(Inline)]
        public static bool equal<T,C>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, C comparer)
            where C : IEqualityComparer<T>
        {
            var count = a.Length;
            if(count != b.Length)
                return false;

            if(count == 0)
                return true;

            for(var i=0; i<count; i++)
                if(!comparer.Equals(Spans.skip(a,i), Spans.skip(b,i)))
                    return false;

            return true;
        }        
    }
}