//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// A grid of natural dimensions M and N such that M*N <= 16
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size=ByteCount)]
    public struct SubGrid16<M,N,T>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        /// <summary>
        /// The grid state
        /// </summary>
        internal ushort Data;

        /// <summary>
        /// The maximum number of bytes covered by the grid
        /// </summary>
        public const int ByteCount = 2;

        /// <summary>
        /// The maximum grid width
        /// </summary>
        public static N16 W => default;

        [MethodImpl(Inline)]
        internal SubGrid16(ushort src)
            => Data = src;

        [MethodImpl(Inline)]
        internal SubGrid16(SpanBlock16<T> src)
            => Data = src.As<ushort>().First;

        /// <summary>
        /// The exposed grid state
        /// </summary>
        public ushort Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        /// <summary>
        /// The number of allocated cells
        /// </summary>
        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => ByteCount/size<T>();
        }

        /// <summary>
        /// The number of covered bits
        /// </summary>
        public int BitCount
        {
            [MethodImpl(Inline)]
            get => (int)NatCalc.mul<M,N>();
        }

        /// <summary>
        /// The number of rows in the grid
        /// </summary>
        public int RowCount => nat32i<M>();

        /// <summary>
        /// The number of columns in the grid
        /// </summary>
        public int ColCount => nat32i<N>();

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

        /// <summary>
        /// Reads/writes an index-identified cell
        /// </summary>
        [MethodImpl(Inline)]
        public ref T Cell(int index)
            => ref Unsafe.Add(ref Head, index);

        /// <summary>
        /// Extracts row content as a bitvector
        /// </summary>
        public ScalarBits<N,T> this[int index]
        {
            [MethodImpl(Inline)]
            get => BitGrid.row(this,index);
        }

        [MethodImpl(Inline)]
        public SubGrid16<M,N,U> As<U>()
            where U : unmanaged
                => new SubGrid16<M,N,U>(Data);

        [MethodImpl(Inline)]
        public bool Equals(SubGrid16<M,N,T> rhs)
            => Data.Equals(rhs.Data);

        public override bool Equals(object obj)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static implicit operator SubGrid16<M,N,T>(in SpanBlock16<T> src)
            => new SubGrid16<M, N, T>(src);

        [MethodImpl(Inline)]
        public static implicit operator SubGrid16<M,N,T>(ushort src)
            => new SubGrid16<M,N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator ushort(SubGrid16<M,N,T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static bool operator ==(SubGrid16<M,N,T> g1, SubGrid16<M,N,T> g2)
            => g1.Equals(g2);

        [MethodImpl(Inline)]
        public static bool operator !=(SubGrid16<M,N,T> g1, SubGrid16<M,N,T> g2)
            => !g1.Equals(g2);
    }
}