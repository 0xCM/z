//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct bit
    {
        /// <summary>
        /// Computes the minimum number of bytes required to cover a specified number of bits
        /// </summary>
        /// <param name="width">The number of bits for which storage is required</param>
        [MethodImpl(Inline), Op]
        public static uint minbytes(ulong width)
            => (uint)(width/8ul + (width % 8 == 0 ? 0ul : 1ul));
    }
}