//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct Cell16 : IDataCell<Cell16,W16,ushort>
    {
        public const uint Size = 2;

        readonly ushort Data;

        [MethodImpl(Inline)]
        public Cell16(ushort src)
            => Data = src;

        [MethodImpl(Inline)]
        public Cell16(short src)
            => Data = (ushort)src;

        public CellKind Kind
            => CellKind.Cell16;

        public uint Deposit(Span<byte> dst)
        {
            u16(dst) = Data;
            return Size;
        }

        public T Convert<T>()
            where T : unmanaged
                => @as<ushort,T>(Data);

        public ushort Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Cell16 Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        [MethodImpl(Inline)]
        public bool Equals(Cell16 src)
            => Data == src.Data;

        public string Format()
            => Content.FormatHex();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(ushort src)
            => Data == src;

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is Cell16 x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator ushort(Cell16 x)
            => x.Data;

        [MethodImpl(Inline)]
        public static implicit operator uint(Cell16 x)
            => x.Data;

        [MethodImpl(Inline)]
        public static implicit operator ulong(Cell16 x)
            => x.Data;

        [MethodImpl(Inline)]
        public static implicit operator Cell16(ushort x)
            => new Cell16(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell16(Cell8 x)
            => new Cell16(x.Content);

        [MethodImpl(Inline)]
        public static implicit operator Cell32(Cell16 x)
            => new Cell32(x.Content);

        [MethodImpl(Inline)]
        public static implicit operator Cell64(Cell16 x)
            => new Cell64(x);

        [MethodImpl(Inline)]
        public static explicit operator Cell16(Cell32 x)
            => new Cell16((ushort)x);

        [MethodImpl(Inline)]
        public static explicit operator Cell16(Cell64 x)
            => new Cell16((ushort)x);

        [MethodImpl(Inline)]
        public static implicit operator Cell16(byte x)
            => new Cell16((ushort)x);

        [MethodImpl(Inline)]
        public static implicit operator Cell16(short x)
            => new Cell16(x);

        [MethodImpl(Inline)]
        public static explicit operator Cell16(int x)
            => new Cell16((ushort)x);

        [MethodImpl(Inline)]
        public static explicit operator Cell16(uint x)
            => new Cell16((ushort)x);

        [MethodImpl(Inline)]
        public static explicit operator sbyte(Cell16 x)
            => (sbyte)x.Data;

        [MethodImpl(Inline)]
        public static explicit operator byte(Cell16 x)
            => (byte)x.Data;

        [MethodImpl(Inline)]
        public static explicit operator short(Cell16 x)
            => (short)x.Data;

        [MethodImpl(Inline)]
        public static implicit operator Cell16((byte lo, byte hi) src)
            => new Cell16((ushort)(((ushort)src.lo | ((ushort)src.hi << 8))));

        public static Cell16 Empty
            => default(Cell16);
   }
}