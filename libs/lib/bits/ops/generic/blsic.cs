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
        /// Isolate least set bit and complement, computed by dst := ~src | (src - 1),
        /// where all bits in the target are set except for the least set bit in the source
        /// For example, [11101010] |> blsic = [11111101]
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T blsic<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(BitMasks.blsic(uint8(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(BitMasks.blsic(uint16(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(BitMasks.blsic(uint32(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(BitMasks.blsic(uint64(src)));
            else
                throw no<T>();
        }
    }
}