//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct SegVar
    {
        public static SegVar parse(ReadOnlySpan<char> src)
            => new (Char5Seq.parse(src));

        public static SegVar literal(byte n, byte value)
            => new (Char5Seq.literal(n, value));

        public static SegVar literal(BitNumber<byte> src)
            => new (Char5Seq.literal(src));

        readonly Char5Seq Data;

        [MethodImpl(Inline)]
        public SegVar(ulong data)
        {
            Data = (Char5Seq)data;
        }

        [MethodImpl(Inline)]
        public SegVar(Char5 c)
        {
            Data = new (c);
        }

        [MethodImpl(Inline)]
        public SegVar(Char5Seq src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public SegVar(ReadOnlySpan<Char5> src)
        {
            Data = new (src);
        }

        [MethodImpl(Inline)]
        public SegVar(params Char5[] src)
        {
            Data = new (src);
        }

        public bool IsLiteral()
            => Data.IsLiteral();

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static explicit operator ulong(SegVar src)
            => (ulong)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator SegVar(ulong src)
            => new SegVar(src);

        [MethodImpl(Inline)]
        public static implicit operator SegVar(char c)
            => new SegVar(Char5.parse(c));
    }
}