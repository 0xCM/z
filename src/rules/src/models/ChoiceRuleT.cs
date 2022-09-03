//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
        public class ChoiceRule<T> : RuleExpr<ChoiceRule<T>,Index<T>>, IChoiceRule
            where T : IRuleExpr
        {
            [MethodImpl(Inline)]
            public ChoiceRule(Index<T> src)
                : base(src)
            {

            }

            public Index<IRuleExpr> Terms
                => Content.Map(x => (IRuleExpr)x);

            public override string Format()
                => Content.Delimit(Chars.Pipe, fence:Fenced.Angled).Format();

            [MethodImpl(Inline)]
            public static implicit operator ChoiceRule<T>(T[] src)
                => new ChoiceRule<T>(src);
        }
    }
}