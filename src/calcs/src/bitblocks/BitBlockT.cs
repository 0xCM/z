//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// A data structure that covers and arbitrary number of 256-bit blocks of packed bits
    /// </summary>
    public readonly ref struct BitBlock<T>
        where T : unmanaged
    {
        /// <summary>
        /// The bitvector content
        /// </summary>
        readonly SpanBlock256<T> data;

        /// <summary>
        /// The actual number of bits that are represented by the vector
        /// </summary>
        public readonly uint BitCount;

        /// <summary>
        /// The maximum number of bits that can be placed a single segment segment
        /// </summary>
        public static uint CellWidth
            => width<T>();

        [MethodImpl(Inline)]
        public BitBlock(T src, uint bitcount)
        {
            data = SpanBlocks.alloc<T>(w256,1);
            data.First = src;
            BitCount = bitcount;
        }

        [MethodImpl(Inline)]
        public BitBlock(Span<T> src, uint n)
        {
            data = SpanBlocks.safeload(w256, src);
            BitCount = n;
        }

        /// <summary>
        /// The underlying cell data
        /// </summary>
        public Span<T> Data
        {
            [MethodImpl(Inline)]
            get => data;
        }

        /// <summary>
        /// Presents the represented data as a span of bytes
        /// </summary>
        public readonly Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => data.Bytes;
        }

        /// <summary>
        /// Is true if at least one enabled bit; false otherwise
        /// </summary>
        public readonly bit NonEmpty
        {
            [MethodImpl(Inline)]
            get => Pop() != 0;
        }

        /// <summary>
        /// A bit-level accessor/manipulator
        /// </summary>
        public bit this[int index]
        {
            [MethodImpl(Inline)]
            get => BitBlocks.testbit(data,index);

            [MethodImpl(Inline)]
            set => BitBlocks.setbit(data, index,value);
        }

        /// <summary>
        /// Retrieves, at most, one cell's worth of bits defined by an inclusive bit index range
        /// </summary>
        /// <param name="first">The linear index of the first bit</param>
        /// <param name="last">The linear index of the last bit</param>
        [MethodImpl(Inline)]
        public T TakeScalarBits(int first, int last)
            => Calcs.bitseg(data, first, last);

        /// <summary>
        /// Extracts the represented data as a bitstring
        /// </summary>
        [MethodImpl(Inline)]
        public readonly BitString ToBitString()
            => data.ToBitString((int)BitCount);

        /// <summary>
        /// Counts the enabled bits
        /// </summary>
        [MethodImpl(Inline)]
        public readonly uint Pop()
        {
            var count = 0u;
            for(var i=0; i< data.CellCount; i++)
                count += gbits.pop(data[i]);
            return count;
        }

        [MethodImpl(Inline)]
        public bool Equals(in BitBlock<T> y)
            => data.Identical(y.data);

        [MethodImpl(Inline)]
        public string Format(BitFormat? fmt = null)
            => ToBitString().Format(fmt);

        public override bool Equals(object obj)
            => throw new NotImplementedException();

        public override int GetHashCode()
            => throw new NotImplementedException();

        public override string ToString()
            => throw new NotImplementedException();

        [MethodImpl(Inline)]
        public static implicit operator BitBlock<T>(Span<T> src)
            => new BitBlock<T>(src, width<T>());

        [MethodImpl(Inline)]
        public static implicit operator BitBlock<T>(T src)
            => new BitBlock<T>(src, width<T>());

        [MethodImpl(Inline)]
        public static bit operator %(in BitBlock<T> x, in BitBlock<T> y)
            => BitBlocks.dot(x,y);

        /// <summary>
        /// Computes the bitwise complement of the operand
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitBlock<T> operator ~(in BitBlock<T> src)
            => default;

        /// <summary>
        /// Returns true if the source vector is nonzero, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator true(in BitBlock<T> src)
            => src.NonEmpty;

        /// <summary>
        /// Returns false if the source vector is the zero vector, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator false(in BitBlock<T> src)
            => !src.NonEmpty;

        [MethodImpl(Inline)]
        public static bool operator ==(in BitBlock<T> x, in BitBlock<T> y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator !=(in BitBlock<T> x, in BitBlock<T> y)
            => !x.Equals(y);
    }
}