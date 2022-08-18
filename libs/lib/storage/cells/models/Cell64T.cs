//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    public struct Cell64<T> : IDataCell<Cell64<T>,W64,T>
        where T : unmanaged
    {
        public const uint Width = 64;

        T Data;

        public ulong Content
        {
            [MethodImpl(Inline)]
            get => bw64(Data);
        }

        [MethodImpl(Inline)]
        public Cell64(ulong x0)
            => Data = generic<T>(x0);

        [MethodImpl(Inline)]
        public Cell64(long x0)
            => Data = generic<T>(x0);

        public CellKind Kind
            => CellKind.Cell64;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public Cell32 Lo
        {
            [MethodImpl(Inline)]
            get => (uint)Content;
        }

        public Cell32 Hi
        {
            [MethodImpl(Inline)]
            get => (uint)(Content >> 32);
        }

        public Cell64 Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        [MethodImpl(Inline)]
        public X As<X>()
            where X : struct
                => Numeric.force<X>(Content);

        [MethodImpl(Inline)]
        public bool Equals(ulong src)
            => Content == src;

        [MethodImpl(Inline)]
        public bool Equals(Cell64<T> src)
            => Content == src.Content;

        public string Format()
            => Content.FormatHex();

        public override string ToString()
            => Format();

         public override int GetHashCode()
            => Content.GetHashCode();

        public override bool Equals(object src)
            => src is Cell64 x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell64<T>(int x0)
            => new Cell64<T>(x0);

        [MethodImpl(Inline)]
        public static implicit operator Cell64<T>(long x0)
            => new Cell64<T>(x0);

        [MethodImpl(Inline)]
        public static implicit operator Cell64<T>(ulong x0)
            => new Cell64<T>(x0);

        [MethodImpl(Inline)]
        public static implicit operator ulong(Cell64<T> x)
            => x.Content;

        [MethodImpl(Inline)]
        public static implicit operator Cell64<T>(Cell32 src)
            => new Cell64<T>(src);

        [MethodImpl(Inline)]
        public static explicit operator sbyte(Cell64<T> x)
            => (sbyte)x.Content;

        [MethodImpl(Inline)]
        public static explicit operator short(Cell64<T> x)
            => (short)x.Content;

        [MethodImpl(Inline)]
        public static explicit operator ushort(Cell64<T> x)
            => (ushort)x.Content;

        [MethodImpl(Inline)]
        public static explicit operator uint(Cell64<T> x)
            => (uint)x.Content;

        [MethodImpl(Inline)]
        public static explicit operator int(Cell64<T> x)
            => (int)x.Content;

        [MethodImpl(Inline)]
        public static explicit operator long(Cell64<T> x)
            => (long)x.Content;

        [MethodImpl(Inline)]
        public static implicit operator Cell64<T>((uint lo, uint hi) src)
            => new Cell64<T>((((ulong)src.lo | ((ulong)src.hi << 32))));

        public static Cell64 Empty => default;
   }
}