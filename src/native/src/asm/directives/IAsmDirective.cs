//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAsmDirective : IAsmSourcePart
    {
        text15 Name {get;}

        AsmDirectiveOp Op0 {get;}

        AsmDirectiveOp Op1 {get;}

        AsmDirectiveOp Op2 {get;}

        AsmDirectiveOp Op3 {get;}

        bool INullity.IsEmpty
            => Name.IsEmpty;

        bool INullity.IsNonEmpty
            => Name.IsEmpty;
    }
}