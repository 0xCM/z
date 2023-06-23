//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        public readonly struct VLo128<T> : IUnaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x)
                => vgcpu.vlo(x);
        }

        public readonly struct VLo256<T> : IReducer256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector256<T> x)
                => vgcpu.vlo(x);
        }
    }
}