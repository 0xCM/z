//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct BitGrid32
    {
        uint Data;

        [MethodImpl(Inline)]
        public BitGrid32(uint src)
            => Data = src;

        /// <summary>
        /// The number of covered bits
        /// </summary>
        public byte BitCount => 32;

        /// <summary>
        /// The number of grid cells := {1 | 2 | 4}
        /// </summary>
        public uint CellCount => 4;

        [MethodImpl(Inline)]
        public BitGrid32<U> As<U>()
            where U : unmanaged
                => new BitGrid32<U>(Data);

        [MethodImpl(Inline)]
        public bool Equals(BitGrid32 src)
            => Data.Equals(src.Data);

        public override bool Equals(object src)
            => src is BitGrid32 g && Equals(g);

        public override int GetHashCode()
            => Data.GetHashCode();

        [MethodImpl(Inline)]
        public static implicit operator uint(BitGrid32 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static bit operator ==(BitGrid32 a, BitGrid32 b)
            => a.Data == b.Data;

        [MethodImpl(Inline)]
        public static bit operator !=(BitGrid32 a, BitGrid32 b)
            => a.Data != b.Data;
    }
}