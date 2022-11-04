//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class LiteralRule<T> : RuleExpr<T>, ILiteralRule<T>
    {
        public LiteralRule(T src)
            : base(src)
        {

        }

        public override string Format()
            => Content.ToString();

        public override bool IsTerminal
            => true;

        public static implicit operator LiteralRule<T>(T src)
            => new LiteralRule<T>(src);
    }    
}