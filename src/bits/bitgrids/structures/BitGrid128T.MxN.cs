//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    /// <summary>
    /// A grid of natural dimensions M and N such that M*N = W := 128
    /// </summary>
    /// <remarks>Conforming dimensions include 1x128, 128x1, 2x64, 64x2, 4x32, 32x4, 8x16, and 16x8</remarks>
    [StructLayout(LayoutKind.Sequential, Size=StorageSize)]
    [IdentityProvider(typeof(BitGridIdentityProvider))]
    public struct BitGrid128<M,N,T>
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
        public const int StorageSize = 16;

        [MethodImpl(Inline)]
        internal BitGrid128(Vector128<T> data)
            => this.Data = data;

        [MethodImpl(Inline)]
        internal BitGrid128(in SpanBlock128<T> src)
            => this.Data = src.LoadVector();

        /// <summary>
        /// The exposed grid state
        /// </summary>
        public Vector128<T> Content
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
            get => StorageSize/size<T>();
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

        /// <summary>
        /// Reads an index-identified cell
        /// </summary>
        [MethodImpl(Inline)]
        public T Cell(int cell)
            => Data.GetElement(cell);

        [MethodImpl(Inline)]
        public bool Equals(BitGrid128<M,N,T> rhs)
            => gcpu.vtestc(gcpu.veq(Data,rhs));

        public override bool Equals(object obj)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static implicit operator Vector128<T>(in BitGrid128<M,N,T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator SpanBlock128<T>(in BitGrid128<M,N,T> src)
            => src.Data.ToBlock();

        /// <summary>
        /// Creates a grid from the leading source block
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline)]
        public static implicit operator BitGrid128<M,N,T>(in SpanBlock128<T> src)
            => new BitGrid128<M,N,T>(src);

        /// <summary>
        /// Creates a grid from a generic vector
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline)]
        public static implicit operator BitGrid128<M,N,T>(Vector128<T> src)
            => new BitGrid128<M,N,T>(src);

        /// <summary>
        /// Creates a grid from a 128x8u vector
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline)]
        public static implicit operator BitGrid128<M,N,T>(Vector128<byte> src)
            => new BitGrid128<M,N,T>(src.As<byte,T>());

        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> operator & (in BitGrid128<M,N,T> gx, in BitGrid128<M,N,T> gy)
            => BitGrid.and(gx,gy);

        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> operator | (in BitGrid128<M,N,T> gx, in BitGrid128<M,N,T> gy)
            => BitGrid.or(gx, gy);

        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> operator ^ (in BitGrid128<M,N,T> gx, in BitGrid128<M,N,T> gy)
            => BitGrid.xor(gx, gy);

        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> operator ~ (in BitGrid128<M,N,T> gx)
            => BitGrid.not(gx);

        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> operator - (in BitGrid128<M,N,T> gx)
            => BitGrid.negate(gx);

        [MethodImpl(Inline)]
        public static bit operator ==(in BitGrid128<M,N,T> g1, in BitGrid128<M,N,T> g2)
            => BitGrid.same(g1,g2);

        [MethodImpl(Inline)]
        public static bit operator !=(in BitGrid128<M,N,T> g1, in BitGrid128<M,N,T> g2)
            => !BitGrid.same(g1,g2);
    }
}