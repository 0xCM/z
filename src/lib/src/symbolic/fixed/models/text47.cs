//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = FixedChars;

    public struct text47 : ISizedString<text47,byte>
    {
        public const byte MaxLength = 47;

        public const byte PointSize = 1;

        public const uint Size = 48;

        static N47 N => default;

        public int Capacity => (int)N.NatValue;

        [StructLayout(LayoutKind.Sequential, Size=16*3, Pack=1)]
        internal struct StorageType
        {
            ulong A;

            ulong B;

            ulong C;

            ulong D;

            ulong E;

            ulong F;

            public Span<byte> Bytes
            {
                [MethodImpl(Inline)]
                get => bytes(this);
            }

            public char this[byte i]
            {
                [MethodImpl(Inline)]
                get => (char)Cell(i);
            }

            [MethodImpl(Inline)]
            public ref byte Cell(byte i)
                => ref seek(Bytes,i);

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => D == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => D != 0;
            }

            public static StorageType Empty => default;
        }

        internal StorageType Storage;

        [MethodImpl(Inline)]
        internal text47(in StorageType data)
        {
            Storage = data;
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
            get => Storage.Cell(47);
        }

        public char this[byte index]
        {
            [MethodImpl(Inline)]
            get => Storage[index];
        }
        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Storage.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Storage.IsNonEmpty;
        }

        public uint CharCapacity => MaxLength;

        public BitWidth CharWidth => PointSize*8;

        public BitWidth StorageWidth => size<StorageType>();

        public string Format()
            => api.format(this);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => api.hash(this);
        }

        public override string ToString()
            => Format();

        public bool Equals(text47 src)
            => api.eq(this,src);

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object src)
            => src is text47 x && Equals(x);

        public int CompareTo(text47 src)
            => Format().CompareTo(src.Format());

        [MethodImpl(Inline)]
        public static bool operator ==(text47 a, text47 b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(text47 a, text47 b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator text47(string src)
            => api.txt(N,src);

        [MethodImpl(Inline)]
        public static implicit operator text47(ReadOnlySpan<char> src)
            => api.txt(N,src);

        [MethodImpl(Inline)]
        public static implicit operator text47(ReadOnlySpan<byte> src)
            => api.txt(N,src);

        public static text47 Empty => default;
    }
}