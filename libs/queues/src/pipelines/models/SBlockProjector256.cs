//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct SBlockProjector256<P,S,T> : ISpanBlockProjector256<S,T>
        where P : IVMap256<S,T>
        where S : unmanaged
        where T : unmanaged
    {
        P VMap;

        uint Counter;

        [MethodImpl(Inline)]
        public SBlockProjector256(P vmap)
        {
            VMap = vmap;
            Counter = 0;
        }

        [MethodImpl(Inline)]
        public uint Map(in SpanBlock256<S> src, in SpanBlock256<T> dst)
        {
            var blocks = src.BlockCount;
            for(var i=0; i<blocks; i++)
            {
                gcpu.vstore(VMap.Invoke(gcpu.vload(src,i)), dst,i);
                Counter++;
            }
            return Counter;
        }
    }
}