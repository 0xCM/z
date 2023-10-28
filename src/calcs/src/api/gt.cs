//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static CalcHosts;
using static ApiClassKind;

partial struct Calcs
{
    [MethodImpl(Inline), Factory(Gt), Closures(Closure)]
    public static Gt<T> gt<T>()
        where T : unmanaged
            => default;

    [MethodImpl(Inline), Factory(Gt), Closures(Closure)]
    public static VGt128<T> vgt<T>(W128 w)
        where T : unmanaged
            => default;

    [MethodImpl(Inline), Factory(Gt), Closures(Closure)]
    public static VGt256<T> vgt<T>(W256 w)
        where T : unmanaged
            => default;

    [MethodImpl(Inline), Factory(Gt), Closures(Closure)]
    public static Gt128<T> gt<T>(W128 w)
        where T : unmanaged
            => default;

    [MethodImpl(Inline), Factory(Gt), Closures(Closure)]
    public static Gt256<T> gt<T>(W256 w)
        where T : unmanaged
            => default;

    [MethodImpl(Inline), Gt, Closures(Closure)]
    public static Span<bit> gt<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<bit> dst)
        where T : unmanaged
            => gcalc.apply(gt<T>(), a, b, dst);

    [MethodImpl(Inline), Gt, Closures(Closure)]
    public static SpanBlock128<T> gt<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
        where T : unmanaged
            => gt<T>(w128).Invoke(a, b, dst);

    [MethodImpl(Inline), Gt, Closures(Closure)]
    public static SpanBlock256<T> gt<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
        where T : unmanaged
            => gt<T>(w256).Invoke(a, b, dst);
}
