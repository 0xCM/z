//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct ApiEval
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static PairEvalResults<T> pairs<T>(in Pair<string> labels, in Pairs<T> dst)
            where T : unmanaged
                => new PairEvalResults<T>(labels, dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryEvaluations<T> unary<T>(T[] src, in PairEvalResults<T> dst)
            where T : unmanaged
                => new UnaryEvaluations<T>(src, dst);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BinaryEvaluations<T> binary<T>(in Pairs<T> src, in PairEvalResults<T> dst)
            where T : unmanaged
                => new BinaryEvaluations<T>(src, dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryApiEvalContext<T> context<T>(in ApiEvalContext src, in UnaryEvaluations<T> content)
            where T : unmanaged
                => new UnaryApiEvalContext<T>(src, content);

        [MethodImpl(Inline)]
        public static UnaryApiEvalContext<T> context<T>(BufferTokens buffers, MemberCodeBlock code, in UnaryEvaluations<T> content)
            where T : unmanaged
                => context<T>(new ApiEvalContext(buffers, code), content);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryApiEvalContext<T> context<T>(in ApiEvalContext src, in BinaryEvaluations<T> content)
            where T : unmanaged
                => new BinaryApiEvalContext<T>(src, content);

        [MethodImpl(Inline)]
        public static BinaryApiEvalContext<T> context<T>(BufferTokens buffers, MemberCodeBlock code, in BinaryEvaluations<T> content)
            where T : unmanaged
                => context<T>(new ApiEvalContext(buffers,code), content);
    }
}