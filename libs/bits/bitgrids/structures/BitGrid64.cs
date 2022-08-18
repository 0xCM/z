//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct BitGrid64
    {
        ulong Data;

        [MethodImpl(Inline)]
        public BitGrid64(ulong src)
            => Data = src;

        /// <summary>
        /// The number of covered bits
        /// </summary>
        public byte BitCount => 64;

        /// <summary>
        /// The number of grid cells
        /// </summary>
        public uint CellCount => 8;

        [MethodImpl(Inline)]
        public BitGrid64<U> As<U>()
            where U : unmanaged
                => new BitGrid64<U>(Data);

        [MethodImpl(Inline)]
        public bool Equals(BitGrid64 src)
            => Data.Equals(src.Data);

        public override bool Equals(object src)
            => src is BitGrid64 g && Equals(g);

        public override int GetHashCode()
            => Data.GetHashCode();

        [MethodImpl(Inline)]
        public static implicit operator ulong(BitGrid64 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static bit operator ==(BitGrid64 a, BitGrid64 b)
            => a.Data == b.Data;

        [MethodImpl(Inline)]
        public static bit operator !=(BitGrid64 a, BitGrid64 b)
            => a.Data != b.Data;
    }
}