//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SyntaxRules
    {
        public class OneOrMany<T> : RuleExpr<Index<T>>
        {
            public Index<T> Elements {get;}

            [MethodImpl(Inline)]
            public OneOrMany(Index<T> src)
                : base(src)
            {

            }

            public override string Format()
                =>  string.Format(string.Format("({0})", Content.Delimit()));

            [MethodImpl(Inline)]
            public static implicit operator OneOrMany<T>(T[] src)
                => new OneOrMany<T>(src);
        }    
    }
}