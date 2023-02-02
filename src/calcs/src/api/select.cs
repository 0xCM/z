//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Select), Closures(Closure)]
        public static Select<T> select<T>()
            where T : unmanaged
                => default(Select<T>);

        [MethodImpl(Inline), Factory(Select), Closures(Closure)]
        public static VSelect128<T> vselect<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VSelect128<T>);

        [MethodImpl(Inline), Factory(Select), Closures(Closure)]
        public static VSelect256<T> vselect<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VSelect256<T>);

        [MethodImpl(Inline), Factory(Select), Closures(Closure)]
        public static Select128<T> select<T>(W128 w)
            where T : unmanaged
                => default(Select128<T>);

        [MethodImpl(Inline), Factory(Select), Closures(Closure)]
        public static Select256<T> select<T>(W256 w)
            where T : unmanaged
                => default(Select256<T>);

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static Span<T> select<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, ReadOnlySpan<T> c, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(select<T>(), a, b, c, dst);

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static SpanBlock128<T> select<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> c, SpanBlock128<T> dst)
            where T : unmanaged
                => select<T>(w128).Invoke(a, b, c, dst);

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static SpanBlock256<T> select<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> c, SpanBlock256<T> dst)
            where T : unmanaged
                => select<T>(w256).Invoke(a, b, c, dst);
    }
}