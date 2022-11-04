//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IRule : IRuleExpr
    {
        IRuleExpr Antecedant {get;}

        IRuleExpr Consequent {get;}
    }

    [Free]
    public interface IRule<A,C> : IRule
        where A : IRuleExpr
        where C : IRuleExpr
    {
        new A Antecedant {get;}

        new C Consequent {get;}

        IRuleExpr IRule.Antecedant
            => Antecedant;

        IRuleExpr IRule.Consequent
            => Consequent;
    }
}