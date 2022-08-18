//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;
    using static SFx;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Add), Closures(Closure)]
        public static Add<T> add<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Add, Closures(Closure)]
        public static Span<T> add<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(add<T>(), a, b, dst);

        [MethodImpl(Inline), Factory(Add), Closures(Closure)]
        public static BvAdd<T> bvadd<T>()
            where T : unmanaged
                => sfunc<BvAdd<T>>();

        [MethodImpl(Inline), Factory(Add), Closures(Closure)]
        public static Add128<T> add<T>(W128 w)
            where T : unmanaged
                => default(Add128<T>);

        [MethodImpl(Inline), Factory(Add), Closures(Closure)]
        public static Add256<T> add<T>(W256 w)
            where T : unmanaged
                => default(Add256<T>);

        [MethodImpl(Inline), Factory(Add), Closures(Closure)]
        public static VAdd128<T> vadd<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VAdd128<T>);

        [MethodImpl(Inline), Factory(Add), Closures(Closure)]
        public static VAdd256<T> vadd<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VAdd256<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly SpanBlock256<T> add<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref add<T>(w256).Invoke(a, b, dst);

       [MethodImpl(Inline), Abs, Closures(SignedInts)]
        public static ref readonly SpanBlock128<T> add<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref add<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline)]
        public static ref Block256<N,T> add<N,T>(ref Block256<N,T> a, in Block256<N,T> b)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            add<T>(a,b,a);
            return ref a;
        }
    }
}