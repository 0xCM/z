//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct Cell8 : IDataCell<Cell8,W8,byte>
    {
        public const uint Size = 1;

        readonly byte Data;

        [MethodImpl(Inline)]
        public Cell8(byte src)
            => Data = src;

        [MethodImpl(Inline)]
        public Cell8(sbyte src)
            => Data = (byte)src;

        public CellKind Kind
            => CellKind.Cell8;

        public uint Deposit(Span<byte> dst)
        {
            first(dst) = Data;
            return Size;
        }

        public T Convert<T>()
            where T : unmanaged
                => @as<byte,T>(Data);

        public byte Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Cell8 Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }


        [MethodImpl(Inline)]
        public bool Equals(Cell8 src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public bool Equals(byte src)
            => Data == src;

        public string Format()
            => Content.FormatHex();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is Cell8 x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator byte(Cell8 src)
            => (byte)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Cell8(byte src)
            => new Cell8(src);

        [MethodImpl(Inline)]
        public static implicit operator Cell8(sbyte x0)
            => new Cell8(x0);

        [MethodImpl(Inline)]
        public static implicit operator Cell16(Cell8 x)
            => new Cell16(x.Content);

        [MethodImpl(Inline)]
        public static implicit operator Cell32(Cell8 x)
            => new Cell32(x.Content);

        [MethodImpl(Inline)]
        public static implicit operator Cell64(Cell8 x)
            => new Cell64(x.Content);

        [MethodImpl(Inline)]
        public static explicit operator Cell8(Cell16 x)
            => new Cell8((byte)x.Content);

        [MethodImpl(Inline)]
        public static explicit operator Cell8(Cell32 x)
            => new Cell8((byte)x);

        [MethodImpl(Inline)]
        public static explicit operator Cell8(Cell64 x)
            => new Cell8((byte)x);

        [MethodImpl(Inline)]
        public static explicit operator Cell8(int x)
            => new Cell8((byte)(sbyte)x);

        [MethodImpl(Inline)]
        public static explicit operator Cell8(uint x)
            => new Cell8((byte)x);

        [MethodImpl(Inline)]
        public static explicit operator sbyte(Cell8 x)
            => (sbyte)x.Data;

        [MethodImpl(Inline)]
        public static explicit operator int(Cell8 x)
            => (int)x.Data;

        [MethodImpl(Inline)]
        public static explicit operator uint(Cell8 x)
            => (uint)x.Data;

        [MethodImpl(Inline)]
        public static explicit operator long(Cell8 x)
            => (long)x.Data;

        [MethodImpl(Inline)]
        public static explicit operator ulong(Cell8 x)
            => (ulong)x.Data;

        public static Cell8 Empty => default;
    }
}