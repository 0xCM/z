//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AsmCell : IAsmSourcePart, INullity
    {
        [MethodImpl(Inline)]
        public static AsmCell define(string content, AsmCellKind kind)
            => new (kind, content);

        public readonly @string Content;

        public readonly AsmCellKind PartKind;

        [MethodImpl(Inline)]
        public AsmCell(AsmCellKind kind, string content)
        {
            Content = content;
            PartKind = kind;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.hash(sys.hash(Content.Value),(uint)PartKind);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(AsmCell src)
            => Content == src.Content && PartKind == src.PartKind;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }

        AsmCellKind IAsmSourcePart.PartKind
            => PartKind;

        public string Format()
            => Content;

        public override string ToString()
            => Format();
    }
}