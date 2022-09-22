//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class OneOrManyRule<T> : RuleExpr<Index<T>>
    {
        public Index<T> Elements {get;}

        [MethodImpl(Inline)]
        public OneOrManyRule(Index<T> src)
            : base(src)
        {

        }

        public override string Format()
            =>  string.Format(string.Format("({0})", Content.Delimit()));

        [MethodImpl(Inline)]
        public static implicit operator OneOrManyRule<T>(T[] src)
            => new OneOrManyRule<T>(src);
    }    
}