//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a 16-bit grid of caller-interpreted dimension
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size=2)]
    [IdentityProvider(typeof(BitGridIdentityProvider))]
    public struct BitGrid16<T>
        where T : unmanaged
    {
        /// <summary>
        /// Grid storage
        /// </summary>
        internal ushort Data;

        /// <summary>
        /// The number of covered bits := 16
        /// </summary>
        public byte BitCount => 16;

        [MethodImpl(Inline)]
        public BitGrid16(ushort data)
            => Data = data;

        /// <summary>
        /// The number of grid cells := {1 | 2}
        /// </summary>
        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => 2/size<T>();
        }

        /// <summary>
        /// Covers grid content with a span that defines cells of width := {1 | 2}
        /// </summary>
        public Span<T> Cells
        {
            [MethodImpl(Inline), UnscopedRef]
            get => Data.Bytes().Recover<T>();
        }

        /// <summary>
        /// Yields a mutable reference to the grid's leading storage cell
        /// </summary>
        public ref T Head
        {
            [MethodImpl(Inline), UnscopedRef]
             get => ref first(Cells);
        }

        /// <summary>
        /// Manipulates an index-identified cell, where index := {0 | 1}
        /// </summary>
        public ref T this[int index]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref Cell(index);
        }

        /// <summary>
        /// Reads/writes an index-identified cell
        /// </summary>
        [MethodImpl(Inline), UnscopedRef]
        public ref T Cell(int index)
            => ref Unsafe.Add(ref Head, index);

        [MethodImpl(Inline)]
        public BitGrid16<U> As<U>()
            where U : unmanaged
                => new BitGrid16<U>(Data);

        [MethodImpl(Inline)]
        public bool Equals(BitGrid16<T> rhs)
            => Data.Equals(rhs.Data);

        public override bool Equals(object obj)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static implicit operator ushort(BitGrid16<T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitGrid16<T>(ushort src)
            => new BitGrid16<T>(src);

        [MethodImpl(Inline)]
        public static Bit32 operator ==(BitGrid16<T> gx, BitGrid16<T> gy)
            => gx.Data == gy.Data;

        [MethodImpl(Inline)]
        public static Bit32 operator !=(BitGrid16<T> gx, BitGrid16<T> gy)
            => gx.Data != gy.Data;
    }
}