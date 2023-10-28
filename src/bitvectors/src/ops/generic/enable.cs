//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class BitVectors
{
    /// <summary>
    /// Enables a bit if it is disabled
    /// </summary>
    /// <param name="index">The position of the bit to enable</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BitVector128<T> enable<T>(BitVector128<T> src, byte index)
        where T : unmanaged
    {
        if(index < 64)
            return generic<T>(vcpu.vparts(w128, bits.enable(src.Lo,index), src.Hi));
        else
            return generic<T>(vcpu.vparts(w128, src.Lo, bits.enable(src.Hi,(byte)(index-64))));
    }

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BitVector256<T> enable<T>(BitVector256<T> src, byte pos)
        where T : unmanaged
            => pos < 128 ? vgcpu.vinsert(enable(src.Lo, pos), src.State, LaneIndex.L0) : vgcpu.vinsert(enable(src.Hi, (byte)(pos - 128)), src.State, LaneIndex.L1);
}
