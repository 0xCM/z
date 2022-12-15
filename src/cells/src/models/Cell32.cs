//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct Cell32 : IDataCell<Cell32,W32,uint>
    {
        public const uint Size = 4;

        readonly uint Data;

        [MethodImpl(Inline)]
        public Cell32(uint x0)
            => Data = x0;

        [MethodImpl(Inline)]
        public Cell32(int x0)
            => Data = (uint)x0;

        public CellKind Kind
            => CellKind.Cell32;

        public uint Deposit(Span<byte> dst)
        {
            u32(dst) = Data;
            return Size;
        }

        public T Convert<T>()
            where T : unmanaged
                => @as<uint,T>(Data);

        public Cell32 Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        [MethodImpl(Inline)]
        public bool Equals(Cell32 src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public bool Equals(uint src)
            => Data == src;

        public string Format()
            => Data.FormatHex();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is Cell32 x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell32(uint src)
            => new Cell32(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(Cell32 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static explicit operator Cell32(Cell64 x)
            => new Cell32((uint)x);

        [MethodImpl(Inline)]
        public static implicit operator Cell32(int x0)
            => new Cell32(x0);

        [MethodImpl(Inline)]
        public static explicit operator sbyte(Cell32 x)
            => (sbyte)x.Data;

        [MethodImpl(Inline)]
        public static explicit operator byte(Cell32 x)
            => (byte)x.Data;

        [MethodImpl(Inline)]
        public static explicit operator short(Cell32 x)
            => (short)x.Data;

        [MethodImpl(Inline)]
        public static explicit operator ushort(Cell32 x)
            => (ushort)x.Data;

        [MethodImpl(Inline)]
        public static explicit operator int(Cell32 x)
            => (int)x.Data;

        [MethodImpl(Inline)]
        public static explicit operator long(Cell32 x)
            => x.Data;

        [MethodImpl(Inline)]
        public static explicit operator ulong(Cell32 x)
            => (ulong)x.Data;

        [MethodImpl(Inline)]
        public static implicit operator Cell32((ushort lo, ushort hi) src)
            => new Cell32((((uint)src.lo | ((uint)src.hi << 16))));

       public static Cell32 Empty => default;
    }
}