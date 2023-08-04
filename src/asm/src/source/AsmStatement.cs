//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AsmStatement : ITextual, INullity, IEquatable<AsmStatement>, IComparable<AsmStatement>, IAsmSourcePart
    {
        readonly TextBlock Data;

        [MethodImpl(Inline)]
        public AsmStatement(TextBlock src)
        {
            Data = src;
        }

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

        public AsmCellKind PartKind
        {
            [MethodImpl(Inline)]
            get => AsmCellKind.Instruction;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(AsmStatement src)
            => Data.Equals(src.Data);

        public int CompareTo(AsmStatement src)
            => Data.CompareTo(src.Data);

        public override int GetHashCode()
            => (int)Data.Hash;

        [MethodImpl(Inline)]
        public static implicit operator AsmStatement(string src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmStatement src)
            => new (src.PartKind, src.Format());

        public static AsmStatement Empty
        {
            [MethodImpl(Inline)]
            get => new (EmptyString);
        }
    }
}