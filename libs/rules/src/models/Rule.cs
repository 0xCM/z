//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Rule : IRuleExpr
    {
        public abstract string Format();

        public override string ToString()
            => Format();

        public virtual bool IsTerminal {get; protected set;}
    }
}