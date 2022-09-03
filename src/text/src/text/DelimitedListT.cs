//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DelimitedList<T> : ITextual
    {
        readonly List<T> Data;

        public readonly SeqEnclosureKind Kind;

        public readonly char Delimiter;

        public readonly int CellPad;

        public readonly Fence<char>? Fence;

        [MethodImpl(Inline)]
        public DelimitedList(T[] src, char delimiter = Chars.Comma, SeqEnclosureKind kind = SeqEnclosureKind.Embraced, int pad = 0)
        {
            Data = new List<T>(src);
            CellPad = pad;
            Kind = kind;
            Delimiter = delimiter;
            Fence = kind == SeqEnclosureKind.Embraced ? Fenced.Embraced : Fenced.Bracketed;
        }

        [MethodImpl(Inline)]
        public void Add(in T src)
        {
            Data.Add(src);
        }

        public uint ItemCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }

        public ReadOnlySpan<T> Items
            => Data.ViewDeposited();
        public string Format()
        {
            var content = Delimiting.delimit(Data.ViewDeposited(), Delimiter, CellPad);
            if(Fence != null && sys.nonempty(content))
                return text.enclose(content, Fence.Value);
            else
                return content;
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator DelimitedList<T>(T[] src)
            => new DelimitedList<T>(src);
    }
}