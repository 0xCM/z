//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        public readonly struct VConcat2x128<T> : IMerge2x128x256<T,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector128<T> x, Vector128<T> y)
                => vgcpu.vconcat(x,y);
        }
    }
}