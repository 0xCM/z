//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
        public abstract class RuleExpr<R,T> : RuleExpr<T>
            where R : RuleExpr<R,T>
        {
            protected RuleExpr(T content)
                : base(content)
            {

            }

            public override bool IsTerminal {get; protected set;}
        }
    }
}