//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AsmDirective : AsmDirective<AsmDirective>
    {
        public AsmDirective(asci16 name, AsmDirectiveOp op0 = default, AsmDirectiveOp op1 = default, AsmDirectiveOp op2 = default)
            : base(name,op0,op1,op2)
        {

        }

        [MethodImpl(Inline), Op]
        public static AsmCell cell(string content, AsmCellKind kind)
            => new (kind, content);

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmDirective src)
            => cell(src.Format(), AsmCellKind.Directive);

        public static AsmDirective Empty => new (EmptyString, EmptyString, EmptyString, EmptyString);
    }
}