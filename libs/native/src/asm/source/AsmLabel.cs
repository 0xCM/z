//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmLabel : IAsmSourcePart
    {
        public Identifier Name {get;}

        [MethodImpl(Inline)]
        public AsmLabel(Identifier name)
        {
            Name = text.remove(name.Text, Chars.Colon);
        }

        public AsmCellKind PartKind
        {
            [MethodImpl(Inline)]
            get => AsmCellKind.Label;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public string Format()
            => string.Format("{0}:", Name);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmLabel(string src)
            => new AsmLabel(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmLabel src)
            => AsmCell.define(src.Format(), src.PartKind);

        public static AsmLabel Empty => new AsmLabel(EmptyString);
    }
}