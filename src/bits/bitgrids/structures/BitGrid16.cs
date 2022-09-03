//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct BitGrid16
    {
        ushort Data;

        [MethodImpl(Inline)]
        public BitGrid16(ushort src)
            => Data = src;

        /// <summary>
        /// The number of covered bits := 16
        /// </summary>
        public byte BitCount => 16;

        /// <summary>
        /// The number of grid cells := {1 | 2}
        /// </summary>
        public uint CellCount => 4;

        [MethodImpl(Inline)]
        public BitGrid16<U> As<U>()
            where U : unmanaged
                => new BitGrid16<U>(Data);

        [MethodImpl(Inline)]
        public bool Equals(BitGrid16 src)
            => Data.Equals(src.Data);

        public override bool Equals(object src)
            => src is BitGrid32 g && Equals(g);

        public override int GetHashCode()
            => Data.GetHashCode();

        [MethodImpl(Inline)]
        public static implicit operator ushort(BitGrid16 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static bit operator ==(BitGrid16 a, BitGrid16 b)
            => a.Data == b.Data;

        [MethodImpl(Inline)]
        public static bit operator !=(BitGrid16 a, BitGrid16 b)
            => a.Data != b.Data;
    }
}