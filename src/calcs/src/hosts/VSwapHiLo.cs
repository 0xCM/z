//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        public readonly struct VSwapHiLo128<T> : IUnaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x)
                => vgcpu.vswaphl(x);
        }

        public readonly struct VSwapHiLo256<T> : IUnaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x)
                => vgcpu.vswaphl(x);
        }
    }
}