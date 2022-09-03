//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gbits
    {
        /// <summary>
        /// Sets an identified bit to a supplied value
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="pos">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit, Closures(AllNumeric)]
        public static T set<T>(T src, byte pos, bit state)
            where T : unmanaged
                => state ? enable(src, pos) : disable(src, pos);

        [MethodImpl(Inline)]
        public static T set<T,I>(T src, I index, bit state)
            where T : unmanaged
            where I : unmanaged
                => set<T>(src, u8(index), state);

        /// <summary>
        /// Sets the state of a bit identified by its linear index
        /// </summary>
        /// <param name="index">The 0-based linear bit index</param>
        /// <param name="state">The source state</param>
        /// <param name="io">The input/output buffer</param>
        /// <typeparam name="T">The grid storage segment type</typeparam>
        [MethodImpl(Inline)]
        public static void set<T>(uint index, bit state, Span<T> io)
            where T : unmanaged
                => bitcell(ref first(io),index) = set(bitcell(ref first(io), index),(byte)(index % width<T>()), state);

        [MethodImpl(Inline)]
        public static T setbit<T>(T src, byte pos, bit state)
            where T : unmanaged
                => set(src, pos, state);
    }
}