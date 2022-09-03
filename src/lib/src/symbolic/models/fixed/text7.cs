//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    using FC = FixedChars;
    using api = FixedChars;

    public struct text7 : ISizedString<text7,byte>
    {
        public const byte MaxLength = 7;

        public const byte PointSize = 1;

        public const uint Size = 8;

        public ulong Storage;

        static N7 N => default;

        public int Capacity => (int)N.NatValue;

        [MethodImpl(Inline)]
        internal text7(in ulong data)
        {
            Storage = data;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Bytes);
        }
        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => slice(bytes(Storage),0, MaxLength);
        }

        public ReadOnlySpan<byte> Cells
        {
            [MethodImpl(Inline)]
            get => Bytes;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => (int)(Storage >> 56) & 0xFF;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Storage == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Storage != 0;
        }

        public uint CharCapacity => MaxLength;

        public BitWidth CharWidth => PointSize*8;

        public BitWidth StorageWidth => size<text7>();

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(text7 src)
            => api.eq(this,src);

        public int CompareTo(text7 src)
            => Format().CompareTo(src.Format());

        public override bool Equals(object src)
            => src is text7 n ? Equals(n) : false;

        public override int GetHashCode()
            => (int)FC.hash(this);

        [MethodImpl(Inline)]
        public static bool operator ==(text7 a, text7 b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(text7 a, text7 b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator text7(string src)
            => api.txt(N,src);

        [MethodImpl(Inline)]
        public static implicit operator text7(ReadOnlySpan<char> src)
            => api.txt(N,src);

        [MethodImpl(Inline)]
        public static implicit operator text7(char src)
            => api.txt(N,src);

        public static text7 Empty => default;
    }
}