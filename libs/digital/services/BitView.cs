//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Represents a value as an ordered sequence of bits/bytes
    /// </summary>
    [ApiComplete]
    public unsafe ref struct BitView
    {
        [MethodImpl(Inline)]
        public static BitView create(ulong src)
            => new BitView(bytes(src));

        [MethodImpl(Inline), Closures(UnsignedInts)]
        public static BitView create<T>(T src)
            where T : unmanaged
                => new BitView(bytes(src));

        /// <summary>
        /// The data over which the view is constructed
        /// </summary>
        readonly ReadOnlySpan<byte> Data;

        const byte CellWidth = 8;

        [MethodImpl(Inline)]
        internal BitView(ReadOnlySpan<byte> src)
            => Data = src;

        [MethodImpl(Inline)]
        public bit View(W1 w, ByteSize offset)
        {
            var (i, j) = math.divmod(offset, CellWidth);
            return i < Size ? bit.test(skip(Data,i), (byte)j) : bit.Off;
        }

        [MethodImpl(Inline)]
        public uint2 View(W2 w, ByteSize offset)
        {
            math.divmod(offset, CellWidth, out var d, out var r);
            return d < Size ? (uint2)bits.extract(skip(Data,d), (byte)r, 2) : uint2.Zero;
        }

        [MethodImpl(Inline)]
        public uint3 View(W3 w, ByteSize offset)
        {
            math.divmod(offset, CellWidth, out var d, out var r);
            return d < Size ? (uint3)bits.extract(skip(Data,d), (byte)r, 3) : uint3.Zero;
        }

        [MethodImpl(Inline)]
        public uint4 View(W4 w, ByteSize offset)
        {
            math.divmod(offset, CellWidth, out var d, out var r);
            return d < Size ? (uint4)bits.extract(skip(Data,d), (byte)r, 4) : uint4.Zero;
        }

        [MethodImpl(Inline)]
        public uint5 View(W5 w, ByteSize offset)
        {
            math.divmod(offset, CellWidth, out var d, out var r);
            return d < Size ? (uint5)bits.extract(skip(Data,d), (byte)r, 5) : uint5.Zero;
        }

        [MethodImpl(Inline)]
        public uint6 View(W6 w, ByteSize offset)
        {
            math.divmod(offset, CellWidth, out var d, out var r);
            return d < Size ? (uint6)bits.extract(skip(Data,d), (byte)r, 6) : uint6.Zero;
        }

        [MethodImpl(Inline)]
        public uint7 View(W7 w, ByteSize offset)
        {
            math.divmod(offset, CellWidth, out var d, out var r);
            return d < Size ? (uint7)bits.extract(skip(Data,d), (byte)r, 7) : uint7.Zero;
        }

        [MethodImpl(Inline)]
        public uint8b View(W8 w, ByteSize offset)
        {
            math.divmod(offset, CellWidth, out var d, out var r);
            return d < Size ? (uint8b)bits.extract(skip(Data,d), (byte)r, 8) : uint8b.Zero;
        }

        /// <summary>
        /// The total number of represented bytes
        /// </summary>
        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        /// <summary>
        /// The total number of represented bits
        /// </summary>
        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => (BitWidth)Size;
        }


        public override bool Equals(object obj)
            => true;

        public override int GetHashCode()
            => -1;

        [MethodImpl(Inline)]
        public static bool operator ==(BitView a, BitView b)
            => a.Data.SequenceEqual(b.Data);

        [MethodImpl(Inline)]
        public static bool operator !=(BitView a, BitView b)
            => !(a == b);
    }
}