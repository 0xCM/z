//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    [MethodImpl(Inline),TestC]
    public static bit testc<T>(BitVector128<T> src)
        where T : unmanaged
            => vgcpu.vtestc(src.State);

    [MethodImpl(Inline),TestC]
    public static bit testc<T>(BitVector128<T> src, BitVector128<T> mask)
        where T : unmanaged
            => vgcpu.vtestc(src.State, mask.State);

    [MethodImpl(Inline),TestC]
    public static bit testc<T>(BitVector256<T> src)
        where T : unmanaged
            => vgcpu.vtestc(src.State);

    [MethodImpl(Inline),TestC]
    public static bit testc<T>(BitVector256<T> src, BitVector256<T> mask)
        where T : unmanaged
            => vgcpu.vtestc(src.State, mask.State);
}
