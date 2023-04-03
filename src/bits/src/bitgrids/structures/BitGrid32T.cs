//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a 32-bit grid
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size=4)]
    public struct BitGrid32<T>
        where T : unmanaged
    {
        internal uint Data;

        [MethodImpl(Inline)]
        internal BitGrid32(uint src)
            => Data = src;

        /// <summary>
        /// The number of covered bits
        /// </summary>
        public byte BitCount => 32;

        /// <summary>
        /// The number of grid cells := {1 | 2 | 4}
        /// </summary>
        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => 4/size<T>();
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Data.Bytes().Recover<T>();
        }

        /// <summary>
        /// Yields a mutable reference to the grid's leading storage cell
        /// </summary>
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
        /// Slices a sequence of bits
        /// </summary>
        public ScalarBits<T> this[byte start, byte count]
        {
            [MethodImpl(Inline)]
            get => BitGrid.slice(this, start, count);
        }

        [MethodImpl(Inline)]
        public BitGrid32<U> As<U>()
            where U : unmanaged
                => new BitGrid32<U>(Data);

        [MethodImpl(Inline)]
        public bool Equals(BitGrid32<T> rhs)
            => Data.Equals(rhs.Data);

        public override bool Equals(object obj)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static implicit operator uint(BitGrid32<T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitGrid32(BitGrid32<T> src)
            => new BitGrid32(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator BitGrid32<T>(BitGrid32 src)
            => new BitGrid32<T>(src);

        [MethodImpl(Inline)]
        public static bit operator ==(BitGrid32<T> gx, BitGrid32<T> gy)
            => gx.Data == gy.Data;

        [MethodImpl(Inline)]
        public static bit operator !=(BitGrid32<T> gx, BitGrid32<T> gy)
            => gx.Data != gy.Data;
    }
}