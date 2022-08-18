//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Options), Op]
        public static bool equals(object? a, object? b)
            => RuntimeHelpers.Equals(a,b);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static bool equals<T>(T a, T b)
            where T : unmanaged
                => a.Equals(b);

        [MethodImpl(Options), Op]
        public static bool equals(string a, string b)
            => string.Equals(a, b);

        [MethodImpl(Options), Op]
        public static bool equals(string a, string b, StringComparison options)
            => string.Equals(a, b, options);
    }
}