//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
   partial class BitVectors
    {
        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline),TestC]
        public static bit testc(BitVector8 src)
            => (byte.MaxValue & src.State) == byte.MaxValue;

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline),TestC]
        public static bit testc(BitVector16 src)
            => (ushort.MaxValue & src.State) == ushort.MaxValue;

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline),TestC]
        public static bit testc(BitVector32 src)
            => (uint.MaxValue & src.State) == uint.MaxValue;

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline),TestC]
        public static bit testc(BitVector64 src)
            => (ulong.MaxValue & src.State) == ulong.MaxValue;
    }
}