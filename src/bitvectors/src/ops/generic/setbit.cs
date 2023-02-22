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
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="index">The position of the bit to enable</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector128<T> setbit<T>(BitVector128<T> src, byte index, bit state)
            where T : unmanaged
        {
            if(index < 64)
                return generic<T>(vparts(w128, bits.set(src.Lo,index,state), src.Hi));
            else
                return generic<T>(vparts(w128, src.Lo, bits.set(src.Hi,(byte)(index-64),state)));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector256<T> setbit<T>(BitVector256<T> src, byte pos, bit state)
            where T : unmanaged
                => pos < 127
                ? vgcpu.vinsert(setbit(src.Lo, pos, state), src.State, LaneIndex.L0)
                : vgcpu.vinsert(setbit(src.Hi, pos, state), src.State, LaneIndex.L1);
    }
}