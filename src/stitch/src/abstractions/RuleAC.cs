//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Rule<A,C> : Rule
        where A : IRuleExpr
        where C : IRuleExpr
    {

        public A Antecedant {get;}

        public C Consequent {get;}

        protected Rule(A a, C c)
        {
            Antecedant = a;
            Consequent = c;
        }
    }
}