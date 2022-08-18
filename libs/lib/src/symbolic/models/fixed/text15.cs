//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using FC = FixedChars;
    using api = FixedChars;

    public struct text15 : ISizedString<text15,byte>
    {
        public const byte MaxLength = 15;

        public const byte PointSize = 1;

        public const uint Size = 16;

        public static W128 W => default;

        static N15 N => default;

        public int Capacity => (int)N.NatValue;

        [StructLayout(LayoutKind.Sequential, Size=16, Pack=1)]
        internal struct StorageType
        {
            ulong A;

            ulong B;

            public Span<byte> Bytes
            {
                [MethodImpl(Inline)]
                get => bytes(this);
            }

            [MethodImpl(Inline)]
            public ref byte Cell(byte i)
                => ref seek(Bytes,i);

            public char this[byte i]
            {
                [MethodImpl(Inline)]
                get => (char)Cell(i);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => A == 0 && B == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => A != 0 || B != 0;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => alg.hash.combine(alg.hash.calc(A), alg.hash.calc(B));
            }

            [MethodImpl(Inline)]
            public bool Equals(StorageType src)
                => A == src.A && B == src.B;

            public static StorageType Empty => default;
        }

        internal StorageType Storage;

        [MethodImpl(Inline)]
        internal text15(in StorageType data)
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

        public char this[byte index]
        {
            [MethodImpl(Inline)]
            get => Storage[index];
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Storage.Cell(15);
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Storage);
        }

        public string Format()
            => FC.format(this);

        public override string ToString()
            => Format();

        public bool Equals(text15 src)
            => Storage.Equals(src.Storage);
        public int CompareTo(text15 src)
            => Format().CompareTo(src.Format());

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object src)
            => src is text15 x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator text15(string src)
            => api.txt(N,src);

        [MethodImpl(Inline)]
        public static implicit operator text15(ReadOnlySpan<char> src)
            => api.txt(N,src);

        [MethodImpl(Inline)]
        public static implicit operator text15(ReadOnlySpan<byte> src)
            => api.txt(N,src);

        [MethodImpl(Inline)]
        public static bool operator ==(text15 a, text15 b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(text15 a, text15 b)
            => !a.Equals(b);

        public static text15 Empty => default;
    }
}