//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class gbits
    {
        /// <summary>
        /// Disables a sequence of 8 source bits starting at a specified index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The index at which to begin clearing bits</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T disable8<T>(T src, byte index)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return default;
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.disable8(uint16(src), index));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.disable8(uint32(src), index));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.disable8(uint64(src), index));
            else
                throw no<T>();
        }
    }
}