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
        /// Disables an identified source bit
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="pos">The 0-based index of the bit to change</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Disable, Closures(AllNumeric)]
        public static T disable<T>(T src, byte pos)
            where T : unmanaged
        {
            if(size<T>() == 1)
                 return generic<T>(bits.disable(uint8(src), pos));
            else if (size<T>() == 2)
                 return generic<T>(bits.disable(uint16(src), pos));
            else if (size<T>() == 4)
                 return generic<T>(bits.disable(uint32(src), pos));
            else
                 return generic<T>(bits.disable(uint64(src), pos));
        }
    }
}