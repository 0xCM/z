//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public static partial class XTend
    {
        /// <summary>
        /// Transforms a bitstring into a literal logic sequence
        /// </summary>
        /// <param name="bs">The source bitstring</param>
        public static LiteralLogicSeqExpr ToLogicSeq(this BitString bs)
        {
            var count = bs.Length;
            if(count == 0)
                return LiteralLogicSeqExpr.Empty;

            var buffer = sys.alloc<bit>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<buffer.Length; i++)
                seek(dst,i) = bs[i];
            return new LiteralLogicSeqExpr(buffer);
        }

        /// <summary>
        /// Transforms a bitstring into a literal logic sequence of natural length
        /// </summary>
        /// <param name="bs">The source bitstring</param>
        /// <typeparam name="N">The length type</typeparam>
        [MethodImpl(Inline)]
        public static LiteralLogixSeqExpr<N> ToLogicSeq<N>(this BitString src, N n = default)
            where N : unmanaged, ITypeNat
        {
            Require.equal<N>(src.Length);
            return new LiteralLogixSeqExpr<N>(src.ToLogicSeq().Terms);
        }
    }
}