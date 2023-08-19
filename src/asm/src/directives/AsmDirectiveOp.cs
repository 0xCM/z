//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a directive operand
    /// </summary>
    public readonly struct AsmDirectiveOp : IAsmSourcePart
    {
        public static AsmDirectiveOp noprefix => "noprefix";

        public readonly @string Value;

        [MethodImpl(Inline)]
        public AsmDirectiveOp(string value)
        {
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsNonEmpty;
        }

        AsmCellKind IAsmSourcePart.PartKind
            => AsmCellKind.DirectiveOp;

        public string Format()
            => Value;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmDirectiveOp(string src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmDirectiveOp src)
            => new (AsmCellKind.DirectiveOp, src.Value);

        public static AsmDirectiveOp Empty => new AsmDirectiveOp(EmptyString);
    }
}