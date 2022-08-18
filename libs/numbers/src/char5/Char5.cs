//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly partial struct Char5 : IComparable<Char5>
    {
        [MethodImpl(Inline)]
        public static Char5 parse(char c)
        {
            var dst = Char5.Empty;
            if(letter(c))
                dst = (Code)(c - Base);
            else if(c == '0')
                dst = new(Code.Zero);
            else if(c == '1')
                dst = Code.One;
            else if(c == ' ')
                dst = Code.Space;
            else if(c == '_')
                dst = Code.Underscore;
            return dst;
        }

        [MethodImpl(Inline)]
        public static bool letter(char c)
            => (c >= 'a' && c<= 'z');

        [MethodImpl(Inline)]
        public static bool symbol(char c)
            => c == '_' || c == '/';

        [MethodImpl(Inline)]
        public static bool digit(char c)
            => c == '0' || c == '1';

        [MethodImpl(Inline)]
        public static bool letter(Code c)
            => c >= Code.A && c <= Code.Z;

        [MethodImpl(Inline)]
        public static bool symbol(Code c)
            => c == Code.Underscore || c == Code.Space;

        [MethodImpl(Inline)]
        public static bool digit(Code c)
            => c == Code.Zero || c == Code.One;

        [MethodImpl(Inline)]
        public static bool valid(char c)
            => symbol(c) || letter(c) || digit(c);

        [MethodImpl(Inline)]
        public static bool valid(AsciCode src)
            => valid((char)src);

        readonly byte Index;

        [MethodImpl(Inline)]
        public Char5(Code code)
        {
            Index = (byte)code;
        }

        [MethodImpl(Inline)]
        public Char5(AsciCode c)
        {
            if(valid(c))
                Index = (byte)c;
            else
                Index = 0;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Index == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Index != 0;
        }

        [MethodImpl(Inline)]
        public char ToAsci()
            => (char)skip(AsciCodes,Index);

        public string Format()
            => $"{ToAsci()}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(Char5 src)
            => Index.CompareTo(src.Index);

        [MethodImpl(Inline)]
        public bool Equals(Char5 src)
            => Index == src.Index;

        [MethodImpl(Inline)]
        public override bool Equals(object src)
            => src is Char5 c && Equals(c);

        public override int GetHashCode()
            => Index;

        [MethodImpl(Inline)]
        public static explicit operator byte(Char5 src)
            => src.Index;

        [MethodImpl(Inline)]
        public static explicit operator ushort(Char5 src)
            => src.Index;

        [MethodImpl(Inline)]
        public static explicit operator uint(Char5 src)
            => src.Index;

        [MethodImpl(Inline)]
        public static explicit operator ulong(Char5 src)
            => src.Index;

        [MethodImpl(Inline)]
        public static implicit operator char(Char5 src)
            => src.ToAsci();

        [MethodImpl(Inline)]
        public static implicit operator Char5(char c)
            => parse(c);

        [MethodImpl(Inline)]
        public static implicit operator Char5(AsciCode c)
            => new Char5(c);

        [MethodImpl(Inline)]
        public static implicit operator Char5(Code c)
            => new Char5(c);

        [MethodImpl(Inline)]
        public static bool operator ==(Char5 a, Char5 b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Char5 a, Char5 b)
            => !a.Equals(b);

        public static Char5 Empty => default;
    }
}