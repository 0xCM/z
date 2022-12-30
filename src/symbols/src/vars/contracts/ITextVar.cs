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

    public interface ITextVar<K> : ITextVar
        where K : ITextVarExpr
    {
        new K Expr {get;}

        ITextVarExpr ITextVar.Expr
            => Expr;
    }
}