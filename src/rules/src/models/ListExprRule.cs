//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ListExprRule : RuleExpr<Index<IRuleExpr>>, IListRule
    {
        public Index<IRuleExpr> Terms
            => Content;

        public ListExprRule(IRuleExpr[] src)
            : base(src)
        {

        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Terms.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Terms.IsNonEmpty;
        }

        public override string Format()
            => Terms.Delimit(Chars.Comma, fence:Fenced.Embraced).Format();

        [MethodImpl(Inline)]
        public static implicit operator ListExprRule(IRuleExpr[] src)
            => new ListExprRule(src);
    }   
}