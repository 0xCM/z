//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static bit equals<T>(BitVector128<T> x, BitVector128<T> y)
        where T : unmanaged
            => vgcpu.vsame(x.State, y.State);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static bit equals<T>(BitVector256<T> x, BitVector256<T> y)
        where T : unmanaged
            => vgcpu.vsame(x.State, y.State);
}
