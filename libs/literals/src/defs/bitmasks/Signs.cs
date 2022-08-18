//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        /// <summary>
        /// [10000000]
        /// </summary>
        [BitMask ("10000000")]
        public const byte SignMask8 = (byte)Pow2x64.P2ᐞ07;

        /// <summary>
        /// [10000000 00000000]
        /// </summary>
        [BitMask ("10000000 00000000")]
        public const ushort SignMask16 = (ushort)Pow2x64.P2ᐞ15;

        /// <summary>
        /// [10000000 00000000 00000000 00000000]
        /// </summary>
        [BitMask ("10000000 00000000 00000000 00000000")]
        public const uint SignMask32 = (uint)Pow2x64.P2ᐞ31;

        /// <summary>
        /// [10000000 00000000 00000000 00000000 00000000 00000000 00000000 00000000]
        /// </summary>
        [BitMask ("10000000 00000000 00000000 00000000 00000000 00000000 00000000 00000000")]
        public const ulong SignMask64 = (ulong)Pow2x64.P2ᐞ63;
    }
}