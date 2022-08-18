//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    /// <summary>
    /// A grid of natural dimensions M and N such that M*N <= W := 64
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size=ByteCount)]
    [IdentityProvider(typeof(BitGridIdentityProvider))]
    public struct SubGrid64<M,N,T>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        /// <summary>
        /// The grid state
        /// </summary>
        internal ulong Data;

        /// <summary>
        /// The number of bytes covered by the grid
        /// </summary>
        public const int ByteCount = 8;

        /// <summary>
        /// The maximum grid width
        /// </summary>
        public static N64 W => default;


        [MethodImpl(Inline)]
        internal SubGrid64(ulong src)
            => this.Data = src;

        [MethodImpl(Inline)]
        internal SubGrid64(SpanBlock64<T> src)
            => this.Data = src.As<ulong>().First;

        /// <summary>
        /// The exposed grid state
        /// </summary>
        public ulong Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Content.Bytes().Recover<T>();
        }

        public ref T Head
        {
            [MethodImpl(Inline)]
            get => ref first(Cells);
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
        /// The number of covered bits
        /// </summary>
        public int BitCount
        {
            [MethodImpl(Inline)]
            get => (int)NatCalc.mul<M,N>();
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
        public SubGrid64<M,N,U> As<U>()
            where U : unmanaged
                => new SubGrid64<M, N, U>(Data);

        [MethodImpl(Inline)]
        public bool Equals(SubGrid64<M,N,T> rhs)
            => Data.Equals(rhs.Data);

        public override bool Equals(object obj)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static implicit operator SubGrid64<M,N,T>(in SpanBlock64<T> src)
            => new SubGrid64<M,N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator SubGrid64<M,N,T>(ulong src)
            => new SubGrid64<M,N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator ulong(SubGrid64<M,N,T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitGrid64<T>(SubGrid64<M,N,T> src)
            => new BitGrid64<T>(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator SubGrid64<M,N,T>(BitGrid64<T> src)
            => new SubGrid64<M,N,T>(src);

        [MethodImpl(Inline)]
        public static bool operator ==(SubGrid64<M,N,T> g1, SubGrid64<M,N,T> g2)
            => g1.Equals(g2);

        [MethodImpl(Inline)]
        public static bool operator !=(SubGrid64<M,N,T> g1, SubGrid64<M,N,T> g2)
            => !g1.Equals(g2);
    }
}