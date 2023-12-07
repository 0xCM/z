//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SyntaxRules
    {
        public class Literal<T> : RuleExpr<T>
        {
            public Literal(T src)
                : base(src)
            {

            }

            public override string Format()
                => Content.ToString();

            public override bool IsTerminal
                => true;

            public static implicit operator Literal<T>(T src)
                => new Literal<T>(src);
        }    
    }
}