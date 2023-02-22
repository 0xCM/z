//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit equals<T>(in BitVector128<T> x, in BitVector128<T> y)
            where T : unmanaged
                => gcpu.vsame(x.State, y.State);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit equals<T>(in BitVector256<T> x, in BitVector256<T> y)
            where T : unmanaged
                => gcpu.vsame(x.State, y.State);
    }
}