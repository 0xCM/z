//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using api = AsmDirectives;

    public sealed class AsmSectionDirective : AsmDirective<AsmSectionDirective>
    {
        public AsmSectionDirective(asci16 name, CoffSectionFlags flags = default, CoffComDatKind comdat = default, AsmDirectiveOp data = default)
            : base(".section", name.Format(), api.operand(api.format(flags)), api.format(comdat), data)
        {

        }
    }
}