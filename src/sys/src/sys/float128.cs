//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static decimal float128<T>(T src)
            => As<T,decimal>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T float128<T>(in decimal src, out T dst)
        {
            dst = @as<decimal,T>(src);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static decimal float128<T>(in T src, out decimal dst)
        {
            dst = @as<T,decimal>(src);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static decimal? float128<T>(T? src)
            where T : unmanaged
                => As<T?,decimal?>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<decimal> float128<T>(Span<T> src)
            where T : struct
                => recover<T,decimal>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<decimal> float128<T>(ReadOnlySpan<T> src)
            where T : struct
                => recover<T,decimal>(src);
    }
}