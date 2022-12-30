//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextVar : INullity, IVar<@string>
    {
        ITextVarExpr Expr {get;}

        bool INullity.IsEmpty
            => sys.empty(Value);
    }
}