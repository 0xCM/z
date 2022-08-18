//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Sized;

    /// <summary>
    /// Specifies data size in bits
    /// </summary>
    public readonly record struct BitWidth : IDataType<BitWidth>
    {
        /// <summary>
        /// Specifies a bit count
        /// </summary>
        public readonly ulong Content;

        /// <summary>
        /// Computes the bit-size of a parametric type
        /// </summary>
        /// <typeparam name="T">The type to measure</typeparam>
        [MethodImpl(Inline)]
        public static ulong measure<T>()
            => sys.width<T>();

        /// <summary>
        /// Computes the quotient q :=  a / bitsize[T] of an operand a and parametric type T
        /// </summary>
        /// <param name="a">The operand</param>
        /// <typeparam name="T">The parametric type from which a bit-width will be determined</typeparam>
        [MethodImpl(Inline)]
        public static ulong div<T>(ulong a)
            where T : unmanaged
                => (ulong)a/(measure<T>());

        /// <summary>
        /// Computes the remainder r :=  a % bitsize[T] of an operand a and parametric type T
        /// </summary>
        /// <param name="a">The operand</param>
        /// <typeparam name="T">The parametric type from which a bit-width will be determined</typeparam>
        [MethodImpl(Inline)]
        public static ulong mod<T>(ulong a)
            where T : unmanaged
                => a % (measure<T>());

        [MethodImpl(Inline)]
        public BitWidth(sbyte bits)
            => Content = (ulong)bits;

        [MethodImpl(Inline)]
        public BitWidth(byte bits)
            => Content = bits;

        [MethodImpl(Inline)]
        public BitWidth(ushort bits)
            => Content = bits;

        [MethodImpl(Inline)]
        public BitWidth(int bits)
            => Content = (ulong)bits;

        [MethodImpl(Inline)]
        public BitWidth(uint bits)
            => Content = bits;

        [MethodImpl(Inline)]
        public BitWidth(long bits)
            => Content = (ulong)bits;

        [MethodImpl(Inline)]
        public BitWidth(ulong bits)
            => Content = bits;

        public Kb Kb
        {
            [MethodImpl(Inline)]
            get => api.kb(this);
        }

        public ByteSize Bytes
        {
            [MethodImpl(Inline)]
            get => Content/8;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Content.GetHashCode();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content != 0;
        }

        public string Format()
            => Content.ToString();

        [MethodImpl(Inline)]
        public bool Equals(BitWidth b)
            => Content == b.Content;

        [MethodImpl(Inline)]
        public int CompareTo(BitWidth src)
            => Content.CompareTo(src.Content);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator long(BitWidth src)
            => (long)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ulong(BitWidth src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator uint(BitWidth src)
            => (uint)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(long src)
            => new BitWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(ulong src)
            => new BitWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(uint src)
            => new BitWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(DataWidth src)
            => new BitWidth((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator DataWidth(BitWidth src)
            => (DataWidth)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(NativeTypeWidth src)
            => new BitWidth((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator NativeTypeWidth(BitWidth src)
            => (NativeTypeWidth)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(NativeVectorWidth src)
            => new BitWidth((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(NumericWidth src)
            => new BitWidth((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator NumericWidth(BitWidth src)
            => (NumericWidth)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(ByteSize src)
            => new BitWidth(src.Content*8);

        [MethodImpl(Inline)]
        public static explicit operator ByteSize(BitWidth src)
            => src.Bytes;

        [MethodImpl(Inline)]
        public static explicit operator BitWidth(byte src)
            => new BitWidth(src);

        [MethodImpl(Inline)]
        public static explicit operator BitWidth(ushort src)
            => new BitWidth(src);

        [MethodImpl(Inline)]
        public static explicit operator int(BitWidth src)
            => (int)src.Content;

        [MethodImpl(Inline)]
        public static explicit operator byte(BitWidth src)
            => (byte)src.Content;

        [MethodImpl(Inline)]
        public static explicit operator ushort(BitWidth src)
            => (ushort)src.Content;

        [MethodImpl(Inline)]
        public static explicit operator double(BitWidth src)
            => src.Content;

        [MethodImpl(Inline)]
        public static BitWidth operator +(BitWidth a, BitWidth b)
            => a.Content + b.Content;

        [MethodImpl(Inline)]
        public static BitWidth operator -(BitWidth a, BitWidth b)
            => a.Content - b.Content;

        [MethodImpl(Inline)]
        public static BitWidth operator *(BitWidth a, BitWidth b)
            => a.Content * b.Content;

        [MethodImpl(Inline)]
        public static BitWidth operator /(BitWidth a, BitWidth b)
            => a.Content / b.Content;

        [MethodImpl(Inline)]
        public static BitWidth operator %(BitWidth a, BitWidth b)
            => a.Content % b.Content;

        /// <summary>
        /// The bit with no size
        /// </summary>
        public static BitWidth Empty
            => default;

        /// <summary>
        /// The bit with no size
        /// </summary>
        public static BitWidth Zero
            => default;
    }
}