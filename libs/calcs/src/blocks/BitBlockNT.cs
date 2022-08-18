//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// A data structure that covers a natural count of packed bits
    /// </summary>
    /// <typeparam name="N">The number of contained bits</typeparam>
    /// <typeparam name="T">The storage cell type</typeparam>
    public readonly ref struct BitBlock<N,T>
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        readonly Span<T> data;

        public BitBlock(Span<T> src)
        {
            var allocated = CellWidth * (uint)src.Length;
            Require.invariant(allocated >= BitCount, () => Format(allocated, BitCount));
            data = src;
        }

        public BitBlock(params T[] src)
            : this(src.AsSpan())
        {

        }

        [MethodImpl(Inline)]
        public BitBlock(Span<T> src, bool skipChecks)
            => data = src;

        /// <summary>
        /// The number of bits covered by a cell
        /// </summary>
        public static uint CellWidth
            => width<T>();

        /// <summary>
        /// The total number of bits covered by the block
        /// </summary>
        public static uint BitCount
            => nat32u<N>();

        public static uint WholeCells
        {
            [MethodImpl(Inline)]
            get => BitCount/CellWidth;
        }

        public static bool EvenlyCovered
        {
            [MethodImpl(Inline)]
            get => BitCount % CellWidth == 0;
        }

        /// <summary>
        /// The minimum number of cells needed to cover a block
        /// </summary>
        public static uint RequiredCells
        {
            [MethodImpl(Inline)]
            get => WholeCells + (EvenlyCovered ? 0u : 1u);
        }

        /// <summary>
        /// The storage capacity needed to cover N-bits distributed over a contiguous T-cell sequence
        /// </summary>
        public static uint RequiredWidth
        {
            [MethodImpl(Inline)]
            get => RequiredCells * CellWidth;
        }

        /// <summary>
        /// The data over which the bitvector is constructed
        /// </summary>
        public Span<T> Data
        {
            [MethodImpl(Inline)]
            get => data;
        }

        /// <summary>
        /// Returns a reference to the leading segment of the underlying storage
        /// </summary>
        public ref T Head
        {
            [MethodImpl(Inline)]
            get => ref first(data);
        }

        /// <summary>
        /// The number of represented bits
        /// </summary>
        public readonly uint Width
        {
            [MethodImpl(Inline)]
            get => BitCount;
        }

        /// <summary>
        /// The number of allocated cells
        /// </summary>
        public readonly int Length
        {
            [MethodImpl(Inline)]
            get => data.Length;
        }

        /// <summary>
        /// A bit-level accessor/manipulator
        /// </summary>
        public bit this[int bitpos]
        {
            [MethodImpl(Inline)]
            get => gbits.readbit(Head, (uint)bitpos);

            [MethodImpl(Inline)]
            set => gbits.set((uint)bitpos, value, data);
        }

        /// <summary>
        /// Counts the vector's enabled bits
        /// </summary>
        [MethodImpl(Inline)]
        public int Pop()
        {
            var count = 0u;
            for(var i=0; i<data.Length; i++)
                count += gbits.pop(Data[i]);
            return (int)count;
        }

        /// <summary>
        /// Returns true if no bits are enabled, false otherwise
        /// </summary>
        public bool Empty
        {
            [MethodImpl(Inline)]
            get => Pop() == 0;
        }

        /// <summary>
        /// Returns true if the vector has at least one enabled bit; false otherwise
        /// </summary>
        public bool Nonempty
        {
            [MethodImpl(Inline)]
            get => Pop() != 0;
        }

        /// <summary>
        /// Sets all the bits in use to the specified state
        /// </summary>
        /// <param name="state">The source state</param>
        public void Fill(bit state)
        {
            if(state)
                data.Fill(Limits.maxval<T>());
            else
                data.Clear();
        }

        [MethodImpl(Inline)]
        public BitBlock<T> Unsize()
            => BitBlocks.load(Data, (int)nat64u<N>());

        [MethodImpl(Inline)]
        public bool Equals(in BitBlock<N,T> rhs)
            => data.Identical(rhs.data);

        public override bool Equals(object obj)
            => false;

        public override int GetHashCode()
            => -3;

        public override string ToString()
            => "%";

        [MethodImpl(Inline)]
        public static implicit operator BitBlock<T>(in BitBlock<N,T> x)
            => new BitBlock<T>(x.data, (uint)new N().NatValue);

        [MethodImpl(Inline)]
        public static BitBlock<N,T> operator &(in BitBlock<N,T> x, in BitBlock<N,T> y)
            => new BitBlock<N,T>(Calcs.and(x.data, y.data, x.data.Replicate()));

        [MethodImpl(Inline)]
        public static BitBlock<N,T> operator |(in BitBlock<N,T> x, in BitBlock<N,T> y)
            => new BitBlock<N,T>(Calcs.or(x.data, y.data, x.data.Replicate()));

        [MethodImpl(Inline)]
        public static BitBlock<N,T> operator ^(in BitBlock<N,T> lhs, in BitBlock<N,T> rhs)
            => new BitBlock<N,T>(Calcs.xor(lhs.data, rhs.data, lhs.data.Replicate()));

        /// <summary>
        /// Computes the bitwise complement of the operand
        /// </summary>
        /// <param name="lhs">The source operand</param>
        [MethodImpl(Inline)]
        public static BitBlock<N,T> operator ~(in BitBlock<N,T> x)
            => new BitBlock<N,T>(Calcs.not(x.data, x.data.Replicate()));

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static bit operator %(in BitBlock<N,T> x, in BitBlock<N,T> y)
            => BitBlocks.dot(x,y);

        /// <summary>
        /// Computes the bitwise complement of the operand
        /// </summary>
        /// <param name="lhs">The source operand</param>
        [MethodImpl(Inline)]
        public static BitBlock<N,T> operator -(in BitBlock<N,T> x)
            => new BitBlock<N,T>(Calcs.negate(x.data, x.data.Replicate()));

        /// <summary>
        /// Returns true if the source vector is nonzero, false otherwise
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator true(in BitBlock<N,T> x)
            => x.Nonempty;

        /// <summary>
        /// Returns false if the source vector is the zero vector, false otherwise
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator false(in BitBlock<N,T> x)
            => !x.Nonempty;

        [MethodImpl(Inline)]
        public static bit operator ==(in BitBlock<N,T> x, in BitBlock<N,T> y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bit operator !=(in BitBlock<N,T> x, in BitBlock<N,T> y)
            => !x.Equals(y);

        const string CapacityExceeded = "The required bit count exceeds allocated capacity";

        static string Format(uint capacity, uint needed)
            => text.concat(CapacityExceeded.PadRight(70), Space, FieldDelimiter, Space, Chars.LBrace,
                    "CellWidth*CellCount", Space, Chars.Eq, Space, capacity, Chars.Space, Chars.Lt, Chars.Space, needed);
    }
}