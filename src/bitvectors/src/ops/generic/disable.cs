//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vcpu;

    partial class BitVectors
    {
        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector128<T> disable<T>(BitVector128<T> src, byte pos)
            where T : unmanaged
                => pos < 64 ? generic<T>(vparts(w128, bits.disable(src.Lo,pos), src.Hi)) : generic<T>(vparts(w128, src.Lo, bits.disable(src.Hi, (byte)(pos-64))));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector256<T> disable<T>(BitVector256<T> src, byte pos)
            where T : unmanaged
                => pos < 128 ? vgcpu.vinsert(disable(src.Lo, pos), src.State, LaneIndex.L0) : vgcpu.vinsert(disable(src.Hi, (byte)(pos - 128)), src.State, LaneIndex.L1);
    }
}