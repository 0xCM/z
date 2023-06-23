//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        public readonly struct VLoadSpan128<T> : ISpanLoader128<T,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(ReadOnlySpan<T> x, int offset)
                => vgcpu.vload(n128,x,offset);
        }

        public readonly struct VLoadSpan256<T> : ISpanLoader256<T,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(ReadOnlySpan<T> x, int offset)
                => vgcpu.vload(n256,x,offset);
        }
    }
}