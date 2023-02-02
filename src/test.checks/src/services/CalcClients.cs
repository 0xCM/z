//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Calcs;

    [ApiHost]
    public readonly struct CalcClients
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public bit dotprod<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => bvdot<T>().Invoke(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public ScalarBits<T> gather<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => bvgather<T>().Invoke(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public ScalarBits<T> nor<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => bvnor<T>().Invoke(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public ScalarBits<T> not<T>(ScalarBits<T> x)
            where T : unmanaged
                => bvnot<T>().Invoke(x);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public ScalarBits<T> xnor<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => bvxnor<T>().Invoke(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public ScalarBits<T> xor<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => bvxor<T>().Invoke(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public int width<T>(ScalarBits<T> x)
            where T : unmanaged
                => bveffwidth<T>().Invoke(x);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public ScalarBits<T> add<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => bvadd<T>().Invoke(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public ScalarBits<T> and<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => bvand<T>().Invoke(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public ScalarBits<T> nand<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => bvnand<T>().Invoke(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public ScalarBits<T> or<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => Calcs.bvor<T>().Invoke(x,y);

        [MethodImpl(Inline), Srl, Closures(Closure)]
        public static SpanBlock128<T> srl<T>(SpanBlock128<T> a, [Imm] byte count, SpanBlock128<T> dst)
            where T : unmanaged
                => Calcs.srl<T>(w128).Invoke(a, count, dst);

        [MethodImpl(Inline), Srl, Closures(Closure)]
        public static SpanBlock256<T> srl<T>(SpanBlock256<T> a, [Imm] byte count, SpanBlock256<T> dst)
            where T : unmanaged
                => Calcs.srl<T>(w256).Invoke(a, count, dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public ScalarBits<T> sub<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => Calcs.bvsub<T>().Invoke(x,y);

        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static SpanBlock128<T> xor<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
            where T : unmanaged
                => Calcs.xor<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static SpanBlock256<T> xor<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
            where T : unmanaged
                => Calcs.xor<T>(w256).Invoke(a, b, dst);
    }
}