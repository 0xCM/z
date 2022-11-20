//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using api = BitGrid;

    /// <summary>
    /// A grid of natural dimensions M and N such that M*N <= W := 128
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size=(int)StorageSize)]
    public struct SubGrid128<M,N,T>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        /// <summary>
        /// The grid state
        /// </summary>
        internal Vector128<T> Data;

        /// <summary>
        /// The number of bytes covered by the grid
        /// </summary>
        public const uint StorageSize = 16;

        /// <summary>
        /// The maximum grid width
        /// </summary>
        public static W128 W => default;

        [MethodImpl(Inline)]
        internal SubGrid128(Vector128<T> data)
            => Data = data;

        [MethodImpl(Inline)]
        internal SubGrid128(in SpanBlock128<T> src)
            => Data = src.LoadVector();

        [MethodImpl(Inline)]
        public BitGrid128<M,N,T> Promote()
            => new BitGrid128<M,N,T>(Data);

        /// <summary>
        /// The exposed grid state
        /// </summary>
        public Vector128<T> Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Data.ToSpan<T>();
        }

        public ref T Head
        {
            [MethodImpl(Inline)]
            get => ref first(Cells);
        }

        /// <summary>
        /// The number of rows in the grid
        /// </summary>
        public uint RowCount => nat32u<M>();

        /// <summary>
        /// The number of columns in the grid
        /// </summary>
        public uint ColCount => nat32u<N>();

        /// <summary>
        /// The number of covered bits
        /// </summary>
        public uint ContentWidth
        {
            [MethodImpl(Inline)]
            get => (uint)NatCalc.mul<M,N>();
        }

        /// <summary>
        /// Reads an index-identified cell
        /// </summary>
        [MethodImpl(Inline)]
        public T Cell(byte cell)
            => Data.GetElement(cell);

        [MethodImpl(Inline)]
        public SubGrid128<M,N,U> As<U>()
            where U : unmanaged
                => Data.As<T,U>();

        [MethodImpl(Inline)]
        public bool Equals(SubGrid128<M,N,T> rhs)
            => gcpu.vsame(Data,rhs.Data);

        public override bool Equals(object src)
            => src is SubGrid128<M,N,T> x ? Equals(x) : false;

        public override int GetHashCode()
            => (int)alg.ghash.calc(Data);

        [MethodImpl(Inline)]
        public static implicit operator Vector128<T>(in SubGrid128<M,N,T> src)
            => src.Data;

        // [MethodImpl(Inline)]
        // public static implicit operator SpanBlock128<T>(in SubGrid128<M,N,T> src)
        //     => src.Data.ToBlock();

        [MethodImpl(Inline)]
        public static implicit operator SubGrid128<M,N,T>(in SpanBlock128<T> src)
            => new SubGrid128<M,N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator SubGrid128<M,N,T>(Vector128<T> src)
            => new SubGrid128<M,N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator BitGrid128<M,N,T>(SubGrid128<M,N,T> src)
            => src.Promote();

        [MethodImpl(Inline)]
        public static implicit operator SubGrid128<M,N,T>(Vector128<byte> src)
            => new SubGrid128<M,N,T>(src.As<byte,T>());

        [MethodImpl(Inline)]
        public static SubGrid128<M,N,T> operator & (in SubGrid128<M,N,T> gx, in SubGrid128<M,N,T> gy)
            => api.subgrid(gx.Promote()  &gy.Promote());

        [MethodImpl(Inline)]
        public static SubGrid128<M,N,T> operator | (in SubGrid128<M,N,T> gx, in SubGrid128<M,N,T> gy)
            => api.subgrid(gx.Promote() | gy.Promote());

        [MethodImpl(Inline)]
        public static SubGrid128<M,N,T> operator ^ (in SubGrid128<M,N,T> gx, in SubGrid128<M,N,T> gy)
            => api.subgrid(gx.Promote() ^ gy.Promote());

        [MethodImpl(Inline)]
        public static SubGrid128<M,N,T> operator ~ (in SubGrid128<M,N,T> gx)
            => api.subgrid(~gx.Promote());

        [MethodImpl(Inline)]
        public static SubGrid128<M,N,T> operator - (in SubGrid128<M,N,T> gx)
            => api.subgrid(-gx.Promote());

        [MethodImpl(Inline)]
        public static bit operator ==(in SubGrid128<M,N,T> g1, in SubGrid128<M,N,T> g2)
            => g1.Promote() == g2.Promote();

        [MethodImpl(Inline)]
        public static bit operator !=(in SubGrid128<M,N,T> g1, in SubGrid128<M,N,T> g2)
            => g1.Promote() != g2.Promote();
    }
}