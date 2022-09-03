//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static SFx;

    partial struct CalcHosts
    {
        public readonly struct VSrlv128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> counts)
                => gcpu.vsrlv(x,counts);

            [MethodImpl(Inline)]
            public T Invoke(T a, T count)
                => gmath.srl(a, Numeric.force<T,byte>(count));
        }

        public readonly struct VSrlv256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> counts)
                => gcpu.vsrlv(x, counts);

            [MethodImpl(Inline)]
            public T Invoke(T a, T count)
                => gmath.srl(a, Numeric.force<T,byte>(count));
        }
    }
}