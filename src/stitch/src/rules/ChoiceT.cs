//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SyntaxRules
    {
        public class Choice<T> : RuleExpr<Choice<T>,Index<T>>, IChoiceRule
            where T : IRuleExpr
        {
            [MethodImpl(Inline)]
            public Choice(Index<T> src)
                : base(src)
            {

            }

            public Index<IRuleExpr> Terms
                => Content.Map(x => (IRuleExpr)x);

            public override string Format()
                => Content.Delimit(Chars.Pipe, fence:Fenced.Angled).Format();

            [MethodImpl(Inline)]
            public static implicit operator Choice<T>(T[] src)
                => new Choice<T>(src);
        }
    }
}