//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
        public class ListExprRule<T> : RuleExpr<Index<T>>, IListRule<T>
            where T : IRuleExpr
        {
            public Index<T> Terms
                => Content;

            public ListExprRule(T[] src)
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
            public static implicit operator ListExprRule<T>(T[] src)
                => new ListExprRule<T>(src);
        }
    }
}