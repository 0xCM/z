
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(Integers), Xors]
        public readonly struct Xors128<T> : IBlockedUnaryImm8Op128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, [Imm] byte count, SpanBlock128<T> dst)
            {
                var blocks = dst.BlockCount;
                for(var block = 0; block < blocks; block++)
                    gcpu.vstore(gcpu.vxors(a.LoadVector(block), count), ref dst.BlockLead(block));
                return dst;
            }
        }

        [Closures(Integers), Xors]
        public readonly struct Xors256<T> : IBlockedUnaryImm8Op256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, [Imm] byte count, SpanBlock256<T> dst)
            {
                var blocks = dst.BlockCount;
                for(var block = 0; block < blocks; block++)
                    gcpu.vstore(gcpu.vxors(a.LoadVector(block), count), ref dst.BlockLead(block));
                return dst;
            }
        }
    }
}