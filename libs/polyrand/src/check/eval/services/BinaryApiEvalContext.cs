//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct BinaryApiEvalContext<T>
        where T : unmanaged
    {
        public ApiEvalContext Context {get;}

        public readonly BinaryEvaluations<T> Target;

        [MethodImpl(Inline)]
        public BinaryApiEvalContext(in ApiEvalContext context, in BinaryEvaluations<T> dst)
        {
            Require.invariant(dst.Source.PointCount == dst.Target.PointCount, () => "no");
            Context = context;
            Target = dst;
        }

        public Pairs<T> Input
        {
            [MethodImpl(Inline)]
            get => Target.Source;
        }

        public PairEvalResults<T> Outcomes
        {
            [MethodImpl(Inline)]
            get => Target.Target;
        }

        public uint PointCount
            => Target.Source.PointCount;

        public BufferTokens Buffers
            => Context.Buffers;

        public MemberCodeBlock ApiCode
            => Context.ApiCode;

        public ApiMember Member
            => Context.Member;

        public ApiCodeBlock ApiBits
            => Context.ApiBits;
    }
}