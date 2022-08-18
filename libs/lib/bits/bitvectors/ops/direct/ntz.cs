//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitVectors
    {
        /// <summary>
        /// Counts the number of trailing zero bits
        /// </summary>
        [MethodImpl(Inline), Ntz]
        public static byte ntz(BitVector8 x)
            => bits.ntz(x.State);

        /// <summary>
        /// Counts the number of trailing zero bits
        /// </summary>
        [MethodImpl(Inline), Ntz]
        public static ushort ntz(BitVector16 x)
            => bits.ntz(x.State);

        /// <summary>
        /// Counts the number of trailing zero bits
        /// </summary>
        [MethodImpl(Inline), Ntz]
        public static uint ntz(BitVector32 x)
            => bits.ntz(x.State);

        /// <summary>
        /// Counts the number of trailing zero bits
        /// </summary>
        [MethodImpl(Inline), Ntz]
        public static ulong ntz(BitVector64 x)
            => bits.ntz(x.State);
    }
}