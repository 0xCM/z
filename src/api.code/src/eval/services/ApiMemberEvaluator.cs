//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static BufferSeqId;

    public readonly struct ApiMemberEvaluator
    {
        readonly BufferTokens Tokens;

        [MethodImpl(Inline)]
        internal ApiMemberEvaluator(BufferTokens src)
            => Tokens = src;

        /// <summary>
        /// Evaluates a binary operator over a pair index and deposits the result into a caller-supplied triple index
        /// </summary>
        /// <param name="api">The api member</param>
        /// <param name="src">The source pairs over which to evaluate the operator</param>
        /// <typeparam name="T">The operand type</typeparam>
        public ref readonly Triples<T> Eval<T>(in MemberCodeBlock api, BinaryOperatorClass op, in Pairs<T> src, in Triples<T> dst)
            where T : unmanaged
        {
            var count = src.PointCount;
            var f = Dynamic.EmitBinaryOp<T>(Tokens[Left], api.Encoded);
            for(var i=0; i<count; i++)
            {
                ref readonly var pair = ref src[i];
                dst[i] = Tuples.triple(pair.Left, pair.Right, f(pair.Left,pair.Right));
            }
            return ref dst;
        }

        /// <summary>
        /// Evaluates a binary operator over a pair index
        /// </summary>
        /// <param name="api">The api member</param>
        /// <param name="src">The source pairs over which to evaluate the operator</param>
        /// <typeparam name="T">The operand type</typeparam>
        public Triples<T> Eval<T>(in MemberCodeBlock api, BinaryOperatorClass op, in Pairs<T> src)
            where T : unmanaged
                => Eval(api,op, src, Tuples.triples<T>(src.PointCount));

        /// <summary>
        /// Evaluates a binary operator over a pair index of fixed types
        /// </summary>
        /// <param name="api">The api member</param>
        /// <param name="src">The source pairs over which to evaluate the operator</param>
        /// <typeparam name="T">The operand type</typeparam>
        public Triples<F> EvalCellular<F>(in MemberCodeBlock api, BinaryOperatorClass op, in Pairs<F> src)
            where F : unmanaged, IDataCell
        {
            var count = src.PointCount;
            var f = Dynamic.EmitBinaryOp<F>(Tokens[Left], api.Encoded);
            var dst = Tuples.triples<F>(src.PointCount);
            for(var i=0; i<count; i++)
            {
                ref readonly var pair = ref src[i];
                dst[i] =  Tuples.triple(pair.Left, pair.Right, f(pair.Left,pair.Right));
            }
            return dst;
        }

        IDynexus Dynamic => Dynops.Dynexus;
    }
}