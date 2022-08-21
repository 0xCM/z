//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool eq<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b)
            where T : IEquatable<T>
        {
            var count = a.Length;
            if(count != b.Length)
                return false;
            for(var i=0u; i<count; i++)
                if(!sys.skip(a, i).Equals(sys.skip(b, i)))
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
                if(!comparer.Equals(sys.skip(a,i), sys.skip(b,i)))
                    return false;

            return true;
        }        

        [MethodImpl(Options), Op]
        public static bool eq(object? a, object? b)
            => RuntimeHelpers.Equals(a,b);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static bool eq<T>(T a, T b)
            where T : unmanaged
                => a.Equals(b);

        [MethodImpl(Options), Op]
        public static bool eq(string a, string b)
            => string.Equals(a, b);

        [MethodImpl(Options), Op]
        public static bool eq(string a, string b, StringComparison options)
            => string.Equals(a, b, options);
    }
}