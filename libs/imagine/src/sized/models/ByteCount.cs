//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Sized;
    using V = ByteCount;

    public readonly record struct ByteCount : IDataType<ByteCount>
    {
        readonly ulong Count;

        [MethodImpl(Inline)]
        public ByteCount(ulong size)
        {
            Count = size;
        }

        [MethodImpl(Inline)]
        public ByteCount(uint size)
        {
            Count = size;
        }

        [MethodImpl(Inline)]
        public ByteCount(ByteSize size)
        {
            Count = size;
        }

        [MethodImpl(Inline)]
        public ByteCount(BitWidth width)
        {
            Count = width/8;
        }

        [MethodImpl(Inline)]
        public ByteCount(Kb src)
        {
            Count = src.Size;
        }

        [MethodImpl(Inline)]
        public ByteCount(Mb src)
        {
            Count = src.Size;
        }

        [MethodImpl(Inline)]
        public ByteCount(Gb src)
        {
            Count = src.Size;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Count;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Size.Bits;
        }

        public Kb Kb
        {
            [MethodImpl(Inline)]
            get => api.kb(Count);
        }

        public Mb Mb
        {
            [MethodImpl(Inline)]
            get => api.mb(Kb);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.hash(Count);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Count == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Count != 0;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Count.ToString("#,#");

        public bool Equals(ByteCount src)
            => Count == src.Count;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(ByteCount src)
            => Count.CompareTo(src.Count);

        [MethodImpl(Inline)]
        public static implicit operator ByteCount(Mb src)
            => new ByteCount(src);

        [MethodImpl(Inline)]
        public static implicit operator ByteCount(Gb src)
            => new ByteCount(src);

        [MethodImpl(Inline)]
        public static implicit operator ByteCount(ulong src)
            => new ByteCount(src);

        [MethodImpl(Inline)]
        public static implicit operator ByteCount(uint src)
            => new ByteCount(src);

        [MethodImpl(Inline)]
        public static implicit operator ByteCount(ByteSize src)
            => new ByteCount(src);

        [MethodImpl(Inline)]
        public static implicit operator ByteCount(BitWidth src)
            => new ByteCount(src);

        /// <summary>
        /// Computes the arithmetic sum of the source operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static V operator +(V x, V y)
            => x.Count + y.Count;

        /// <summary>
        /// Subtracts the second operand from the first.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static V operator - (V x, V y)
            => x.Count - y.Count;

        /// <summary>
        /// Computes the product of the operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static V operator *(in V x, in V y)
            => x.Count * y.Count;

        /// <summary>
        /// Computes the quotient of the operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static V operator /(in V x, in V y)
            => x.Count / y.Count;

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static V operator %(V x, V y)
            => x.Count % y.Count;

        /// <summary>
        /// Negates the source operand
        /// </summary>
        /// <param name="x">The left operand</param>
        [MethodImpl(Inline)]
        public static V operator -(in V src)
            => 0 - src;

        /// <summary>
        /// Determines whether the left operand is less than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bool operator <(V x, V y)
            => x.Count < y.Count;

        /// <summary>
        /// Determines whether the left operand is greater than than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bool operator >(V x, V y)
            => x.Count > y.Count;

        /// <summary>
        /// Determines whether the left operand is less than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bool operator <=(V x, V y)
            => x.Count <= y.Count;

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bool operator >=(V x, V y)
            => x.Count >= y.Count;
    }
}