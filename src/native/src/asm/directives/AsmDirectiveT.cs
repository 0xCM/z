//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public abstract class AsmDirective<T> : IAsmDirective
        where T : AsmDirective<T>
    {
        public readonly text15 Name;

        public readonly AsmDirectiveOp Op0;

        public readonly AsmDirectiveOp Op1;

        public readonly AsmDirectiveOp Op2;

        public readonly AsmDirectiveOp Op3;

        [MethodImpl(Inline)]
        public AsmDirective(text15 name, AsmDirectiveOp op0 = default, AsmDirectiveOp op1 = default, AsmDirectiveOp op2 = default, AsmDirectiveOp op3 = default)
        {
            Name = name.IsNonEmpty ? (name[0] == Chars.Dot ? Spans.slice(name.Bytes,1) : name.Bytes) : default(ReadOnlySpan<byte>);
            Op0 = op0;
            Op1 = op1;
            Op2 = op2;
            Op3 = op3;
        }

        AsmCellKind IAsmSourcePart.PartKind
        {
            [MethodImpl(Inline)]
            get => AsmCellKind.Directive;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        text15 IAsmDirective.Name
            => Name;

        AsmDirectiveOp IAsmDirective.Op0
            => Op0;

        AsmDirectiveOp IAsmDirective.Op1
            => Op1;

        AsmDirectiveOp IAsmDirective.Op2
            => Op2;

        AsmDirectiveOp IAsmDirective.Op3
            => Op3;

        public string Format()
            => AsmDirectives.render(this);

        public override string ToString()
            => Format();

    }
}