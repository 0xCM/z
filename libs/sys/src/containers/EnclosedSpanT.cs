//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly ref struct EnclosedSpan<T>
    {
        public ReadOnlySpan<T> Data {get;}

        public SeqEnclosureKind Kind {get;}

        public char Delimiter {get;}

        [MethodImpl(Inline)]
        public EnclosedSpan(ReadOnlySpan<T> src, SeqEnclosureKind kind = SeqEnclosureKind.Embraced, char delimiter =  Chars.Comma)
        {
            Data = src;
            Kind = kind;
            Delimiter = delimiter;
        }

        public string Format()
            => string.Concat(RP.left(Kind), Delimiting.delimit(Data, Delimiter, 0), RP.right(Kind));

        public override string ToString()
            => Format();
    }
}