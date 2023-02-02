//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct SBlockProjector128<P,S,T> : ISpanBlockProjector128<S,T>
        where P : IVMap128<S,T>
        where S : unmanaged
        where T : unmanaged
    {
        P VMap;

        uint Counter;

        [MethodImpl(Inline)]
        public SBlockProjector128(P vmap)
        {
            VMap = vmap;
            Counter = 0;
        }

        [MethodImpl(Inline)]
        public uint Map(SpanBlock128<S> src, SpanBlock128<T> dst)
        {
            var blocks = src.BlockCount;
            for(var i=0; i<blocks; i++)
            {
                gcpu.vstore(VMap.Invoke(gcpu.vload(src,i)), dst, i);
                Counter++;
            }
            return Counter;
        }
    }
}