//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents the least 8 bits of a unicode code point which, by definition of the encoding, is equivalent to the 7 ascii bits.
    /// </summary>
    [ApiComplete]
    public readonly record struct Utf8Point : IDataType<Utf8Point>, IDataString
    {
        public readonly byte Code;

        [MethodImpl(Inline)]
        internal static Utf8Point From(int src)
            => new Utf8Point((byte)src);

        [MethodImpl(Inline)]
        internal Utf8Point(byte code)
            => Code = code;

        [MethodImpl(Inline)]
        public char ToChar()
            => (char)Code;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Code;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Code == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Code != 0;
        }

        public bool IsSymbol
        {
            [MethodImpl(Inline)]
            get => Char.IsSymbol((char)Code);
        }

        public bool IsControl
        {
            [MethodImpl(Inline)]
            get => Char.IsControl((char)Code);
        }

        public bool IsPunctuation
        {
            [MethodImpl(Inline)]
            get => Char.IsPunctuation((char)Code);
        }

        public bool IsDigit
        {
            [MethodImpl(Inline)]
            get => Char.IsDigit((char)Code);
        }

        public bool IsWhiteSpace
        {
            [MethodImpl(Inline)]
            get => Char.IsWhiteSpace((char)Code);
        }

        public bool IsLetter
        {
            [MethodImpl(Inline)]
            get => Char.IsLetter((char)Code);
        }

        public bool IsLower
        {
            [MethodImpl(Inline)]
            get => Char.IsLower((char)Code);
        }

        public bool IsUpper
        {
            [MethodImpl(Inline)]
            get => Char.IsUpper((char)Code);
        }

        [MethodImpl(Inline)]
        public bool Equals(Utf8Point b)
            => Code == b.Code;

        [MethodImpl(Inline)]
        public int CompareTo(Utf8Point b)
            => Code.CompareTo(b.Code);


        public override int GetHashCode()
            => Hash;

        public string Format()
        {
            var num = Code.ToString("0x");
            var str = IsControl ? "___"  : $"'{ToChar()}'";
            return $"{num} {str}";
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static Utf8Point operator &(Utf8Point a, Utf8Point b)
            => From(a.Code & b.Code);

        [MethodImpl(Inline)]
        public static Utf8Point operator |(Utf8Point a, Utf8Point b)
            => From(a.Code | b.Code);

        [MethodImpl(Inline)]
        public static Utf8Point operator ^(Utf8Point a, Utf8Point b)
            => From(a.Code ^ b.Code);

        [MethodImpl(Inline)]
        public static Utf8Point operator ++(Utf8Point a)
        {
            if(a < MaxValue)
                return From(a.Code + 1);
            else
                return MinValue;
        }

        [MethodImpl(Inline)]
        public static Utf8Point operator --(Utf8Point a)
        {
            if(a > MinValue)
                return From(a.Code - 1);
            else
                return MaxValue;
        }

        [MethodImpl(Inline)]
        public static Utf8Point operator +(Utf8Point a, Utf8Point b)
            => From((a.Code + b.Code) % 128);

        [MethodImpl(Inline)]
        public static bool operator < (Utf8Point a, Utf8Point b)
            => a.Code < b.Code;

        [MethodImpl(Inline)]
        public static bool operator <= (Utf8Point a, Utf8Point b)
            => a.Code <= b.Code;

        [MethodImpl(Inline)]
        public static bool operator > (Utf8Point a, Utf8Point b)
            => a.Code > b.Code;

        [MethodImpl(Inline)]
        public static bool operator >= (Utf8Point a, Utf8Point b)
            => a.Code >= b.Code;

        [MethodImpl(Inline)]
        public static implicit operator char (Utf8Point src)
            => src.ToChar();

        [MethodImpl(Inline)]
        public static implicit operator byte (Utf8Point src)
            => src.Code;

        public static Utf8Point MinValue => From(0);

        public static Utf8Point MaxValue => From(127);
    }
}