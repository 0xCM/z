//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class RuleExpr<T> : Rule, IRuleExpr<T>
    {
        public T Content {get;}

        protected RuleExpr(T value)
        {
            Content = value;
        }

        public override string Format()
            => Content.ToString();
    }
}