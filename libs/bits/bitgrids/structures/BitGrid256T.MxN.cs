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
    /// A grid of natural dimensions M and N such that M*N = W := 256
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size=ByteCount)]
    [IdentityProvider(typeof(BitGridIdentityProvider))]
    public struct BitGrid256<M,N,T>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        /// <summary>
        /// The grid state
        /// </summary>
        internal Vector256<T> Data;

        /// <summary>
        /// The number of bytes covered by the grid
        /// </summary>
        public const int ByteCount = 32;

        [MethodImpl(Inline)]
        internal BitGrid256(Vector256<T> src)
            => Data = src;

        [MethodImpl(Inline)]
        internal BitGrid256(in SpanBlock256<T> src)
            => Data = src.LoadVector();

        /// <summary>
        /// The exposed grid state
        /// </summary>
        public Vector256<T> Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

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

        /// <summary>
        /// Reads an index-identified cell
        /// </summary>
        [MethodImpl(Inline)]
        public T Cell(int cell)
            => Data.GetElement(cell);

        [MethodImpl(Inline)]
        public bool Equals(BitGrid256<M,N,T> rhs)
            => BitGrid.same(this,rhs);

        public override bool Equals(object src)
            => src is BitGrid256<M,N,T> x && Equals(x);

        public override int GetHashCode()
            => Data.GetHashCode();

        [MethodImpl(Inline)]
        public static implicit operator Vector256<T>(in BitGrid256<M,N,T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator SpanBlock256<T>(in BitGrid256<M,N,T> src)
            => src.Data.ToBlock();

        [MethodImpl(Inline)]
        public static implicit operator BitGrid256<M,N,T>(in SpanBlock256<T> src)
            => new BitGrid256<M,N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator BitGrid256<M,N,T>(Vector256<T> src)
            => new BitGrid256<M,N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator BitGrid256<M,N,T>(Vector256<byte> src)
            => new BitGrid256<M,N,T>(src.As<byte,T>());

        [MethodImpl(Inline)]
        public static implicit operator BitGrid256<M,N,T>(Vector256<ushort> src)
            => new BitGrid256<M,N,T>(src.As<ushort,T>());

        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> operator & (in BitGrid256<M,N,T> gx, in BitGrid256<M,N,T> gy)
            => BitGrid.and(gx,gy);

        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> operator | (in BitGrid256<M,N,T> gx, in BitGrid256<M,N,T> gy)
            => BitGrid.or(gx, gy);

        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> operator ^ (in BitGrid256<M,N,T> gx, in BitGrid256<M,N,T> gy)
            => BitGrid.xor(gx, gy);

        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> operator ~ (in BitGrid256<M,N,T> gx)
            => BitGrid.not(gx);

        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> operator - (in BitGrid256<M,N,T> gx)
            => BitGrid.negate(gx);

        [MethodImpl(Inline)]
        public static Bit32 operator ==(in BitGrid256<M,N,T> g1, in BitGrid256<M,N,T> g2)
            => BitGrid.same(g1,g2);

        [MethodImpl(Inline)]
        public static Bit32 operator !=(in BitGrid256<M,N,T> g1, in BitGrid256<M,N,T> g2)
            => !BitGrid.same(g1,g2);
    }
}