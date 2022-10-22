//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct UInt128
    {
        /// <summary>
        /// Shifts the source integer leftwards
        /// </summary>
        /// <param name="x">The integer, represented via paired hi/lo components</param>
        /// <param name="offset">The number of bits to shift letward</param>
        /// <remarks>Follows https://github.com/chfast/intx/include/intx/int128.hpp</remarks>
        [MethodImpl(Inline), Srl]
        public static UInt128 srl(in UInt128 x, byte offset)
            => offset < 64
              ? ((x.Hi >> offset), (x.Lo >> offset) | ((x.Hi << 1) << 63 - offset))
              : offset < 128
              ? (z64, x.Lo >> (offset - 64))
              : default;
    }
}