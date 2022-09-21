//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class IndexRuleExpr<R,T> : RuleExpr<Index<T>>
        where R : IndexRuleExpr<R,T>
        where T : IRuleExpr
    {
        protected IndexRuleExpr(Index<T> terms)
            : base(terms)
        {
            Terms = terms;
        }

        public Index<T> Terms {get;}

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }
    }
    
}