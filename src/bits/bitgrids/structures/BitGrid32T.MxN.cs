//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// A grid of natural dimensions M and N such that M*N = W := 32
    /// </summary>
    /// <remarks>Conforming dimensions include 1x32, 32x1, 2x16, 16x2, 4x8, and 8x4</remarks>
    [StructLayout(LayoutKind.Sequential, Size=ByteCount)]
    public struct BitGrid32<M,N,T>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        /// <summary>
        /// The grid state
        /// </summary>
        internal uint Data;

        /// <summary>
        /// The number of bytes covered by the grid
        /// </summary>
        public const int ByteCount = 4;

        [MethodImpl(Inline)]
        internal BitGrid32(uint src)
            => Data = src;

        [MethodImpl(Inline)]
        internal BitGrid32(SpanBlock32<T> src)
            => Data = src.As<uint>().First;

        /// <summary>
        /// The exposed grid state
        /// </summary>
        public uint Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Data.Bytes().Recover<T>();
        }

        public ref T Head
        {
            [MethodImpl(Inline)]
            get => ref first(Cells);
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => ByteCount/size<T>();
        }

        /// <summary>
        /// The number of covered bits
        /// </summary>
        public Count BitCount
        {
            [MethodImpl(Inline)]
            get => (int)NatCalc.mul<M,N>();
        }

        /// <summary>
        /// The number of rows in the grid
        /// </summary>
        public int RowCount => nat8u<M>();

        /// <summary>
        /// The number of columns in the grid
        /// </summary>
        public int ColCount => nat8u<N>();

        /// <summary>
        /// Reads/writes an index-identified cell
        /// </summary>
        [MethodImpl(Inline)]
        public ref T Cell(int index)
            => ref Unsafe.Add(ref Head, index);

        /// <summary>
        /// Extracts row contant as a bitvector
        /// </summary>
        public ScalarBits<N,T> this[int row]
        {
            [MethodImpl(Inline)]
            get => BitGrid.row(this,row);
        }

        /// <summary>
        /// Converts the current grid defined over T-cells to a target grid defined over U-cells
        /// </summary>
        /// <typeparam name="U">The target type</typeparam>
        [MethodImpl(Inline)]
        public BitGrid32<M,N,U> As<U>()
            where U : unmanaged
                => new BitGrid32<M, N, U>(Data);

        [MethodImpl(Inline)]
        public bool Equals(BitGrid32<M,N,T> rhs)
            => Data.Equals(rhs.Data);

        public override bool Equals(object obj)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static implicit operator BitGrid32<M,N,T>(uint src)
            => new BitGrid32<M,N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(BitGrid32<M,N,T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitGrid32<T>(BitGrid32<M,N,T> src)
            => new BitGrid32<T>(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator BitGrid32<M,N,T>(in SpanBlock32<T> src)
            => new BitGrid32<M,N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator BitGrid32<M,N,T>(BitGrid32<T> src)
            => new BitGrid32<M,N,T>(src.Data);

        [MethodImpl(Inline)]
        public static bool operator ==(BitGrid32<M,N,T> g1, BitGrid32<M,N,T> g2)
            => g1.Equals(g2);

        [MethodImpl(Inline)]
        public static bool operator !=(BitGrid32<M,N,T> g1, BitGrid32<M,N,T> g2)
            => !g1.Equals(g2);
    }

}