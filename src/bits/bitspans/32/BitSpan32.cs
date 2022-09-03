//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static BitSpans32;

    /// <summary>
    /// Defines an anti-succinct data structure for bit representation
    /// </summary>
    public readonly ref partial struct BitSpan32
    {
        internal readonly Span<Bit32> Data;

        [MethodImpl(Inline)]
        public BitSpan32(Span<Bit32> src)
            => Data = src;

        public Span<Bit32> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        ref Bit32 Head
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        /// <summary>
        /// Queries/Manipulates an index-identified bit
        /// </summary>
        public ref Bit32 this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Head, index);
        }

        /// <summary>
        /// Queries/Manipulates an index-identified bit
        /// </summary>
        public ref Bit32 this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Head, index);
        }

        /// <summary>
        /// Packs a segment selection of at most 8 bits
        /// </summary>
        public byte this[int offset, int count, byte t]
        {
            [MethodImpl(Inline)]
            get => BitSpans32.bitslice<byte>(this, offset, count);
        }

        /// <summary>
        /// Packs a segment selection of at most 16 bits
        /// </summary>
        public ushort this[int offset, int count, ushort t]
        {
            [MethodImpl(Inline)]
            get => BitSpans32.bitslice<ushort>(this, offset, count);
        }

        /// <summary>
        /// Packs a segment selection of at most 32 bits
        /// </summary>
        public uint this[int offset, int count, uint t]
        {
            [MethodImpl(Inline)]
            get => BitSpans32.bitslice<uint>(this, offset, count);
        }

        /// <summary>
        /// Packs a segment selection of at most 64 bits
        /// </summary>
        public ulong this[int offset, int count, ulong t]
        {
            [MethodImpl(Inline)]
            get => BitSpans32.bitslice<ulong>(this, offset, count);
        }

        [MethodImpl(Inline)]
        public string Format()
            => format(this);

        [MethodImpl(Inline)]
        public bool Equals(in BitSpan32 rhs)
            => same(this, rhs);

        public override int GetHashCode()
            => throw new NotSupportedException();

        public override bool Equals(object rhs)
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static BitSpan32 operator +(in BitSpan32 head, in BitSpan32 tail)
            => BitSpans32.concat(head,tail);

        [MethodImpl(Inline)]
        public static BitSpan32 operator &(in BitSpan32 x, in BitSpan32 y)
            => and(x,y);

        [MethodImpl(Inline)]
        public static BitSpan32 operator |(in BitSpan32 x, in BitSpan32 y)
            => or(x,y);

        [MethodImpl(Inline)]
        public static BitSpan32 operator ^(in BitSpan32 x, in BitSpan32 y)
            => xor(x,y);

        [MethodImpl(Inline)]
        public static BitSpan32 operator ~(in BitSpan32 x)
            => not(x);

        [MethodImpl(Inline)]
        public static Bit32 operator ==(in BitSpan32 x, in BitSpan32 y)
            => same(x,y);

        [MethodImpl(Inline)]
        public static Bit32 operator !=(in BitSpan32 x, in BitSpan32 y)
            => !same(x,y);
    }
}