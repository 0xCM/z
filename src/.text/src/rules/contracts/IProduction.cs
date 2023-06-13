//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProduction : IRule
    {
        IRuleExpr Source => Antecedant;

        IRuleExpr Target => Consequent;
    }

    public interface IProduction<S,T> : IProduction, IRule<S,T>
        where S : IRuleExpr
        where T : IRuleExpr
    {
        new S Source {get;}

        new T Target {get;}

        S IRule<S,T>.Antecedant
            => Source;

        T IRule<S,T>.Consequent
            => Target;
    }
}