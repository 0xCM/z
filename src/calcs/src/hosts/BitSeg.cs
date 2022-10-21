//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(AllNumeric)]
        public readonly struct BitSeg<T> : IUnaryImm8x2Op<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public T Invoke(T a, byte i0, byte i1)
                => gbits.extract(a,i0,i1);
        }
    }
}