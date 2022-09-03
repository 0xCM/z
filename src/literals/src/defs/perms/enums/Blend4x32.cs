//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines control mask values for constucting a 128-bit target by blending 4 32-bit segments from two 128-bit sources
    /// </summary>
    [SymSource(perms, NBK.Base2), Flags]
    public enum Blend4x32 : byte
    {
        /// <summary>
        /// ([0 1 2 3], [4 5 6 7]) -> [0 1 2 3]
        /// </summary>
        LLLL = 0b0000,

        /// <summary>
        /// ([0 1 2 3], [4 5 6 7]) -> [0 1 2 7]
        /// </summary>
        LLLR = 0b1000,

        /// <summary>
        /// ([0 1 2 3], [4 5 6 7]) -> [4 1 2 3]
        /// </summary>
        RLLL = 0b0001,

        /// <summary>
        /// ([0 1 2 3], [4 5 6 7]) -> [0 1 6 3]
        /// </summary>
        LLRL = 0b0100,

        /// <summary>
        /// ([0 1 2 3], [4 5 6 7]) -> [0 1 6 7]
        /// </summary>
        LLRR = 0b1100,

        LRLL = 0b0010,

        RLRL = 0b0101,

        LRRL = 0b0110,

        RRRL = 0b0111,

        RLLR = 0b1001,

        LRLR = 0b1010,

        RLRR = 0b1011,

        RRLL = 0b0011,

        RRLR = 0b1101,

        LRRR = 0b1110,

        /// <summary>
        /// ([0 1 2 3], [4 5 6 7]) -> [4 5 6 7]
        /// </summary>
        RRRR = 0b1111
    }
}