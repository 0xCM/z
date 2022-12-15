//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct Cell64 : IDataCell<Cell64,W64,ulong>
    {
        public const uint Size = 8;

        readonly ulong Data;

        [MethodImpl(Inline)]
        public Cell64(ulong x0)
            => Data = x0;

        [MethodImpl(Inline)]
        public Cell64(long x0)
            => Data = (ulong)x0;

        public CellKind Kind
            => CellKind.Cell64;

        public uint Deposit(Span<byte> dst)
        {
            u64(dst) = Data;
            return Size;
        }

        public T Convert<T>()
            where T : unmanaged
                => @as<ulong,T>(Data);

        public Cell64 Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        [MethodImpl(Inline)]
        public bool Equals(ulong src)
            => Data == src;

        [MethodImpl(Inline)]
        public bool Equals(Cell64 src)
            => Data == src.Data;

        public string Format()
            => Data.FormatHex();

        public override string ToString()
            => Format();

         public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is Cell64 x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell64(int src)
            => new Cell64(src);

        [MethodImpl(Inline)]
        public static implicit operator Cell64(long src)
            => new Cell64(src);

        [MethodImpl(Inline)]
        public static implicit operator Cell64(ulong src)
            => new Cell64(src);

        [MethodImpl(Inline)]
        public static implicit operator ulong(Cell64 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Cell64(Cell32 src)
            => new Cell64(src);

        [MethodImpl(Inline)]
        public static explicit operator sbyte(Cell64 src)
            => (sbyte)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator byte(Cell64 src)
            => (byte)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator short(Cell64 src)
            => (short)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator ushort(Cell64 src)
            => (ushort)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator uint(Cell64 src)
            => (uint)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator int(Cell64 src)
            => (int)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator long(Cell64 src)
            => (long)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Cell64((uint lo, uint hi) src)
            => new Cell64((((ulong)src.lo | ((ulong)src.hi << 32))));

        public static Cell64 Empty => default;
   }
}