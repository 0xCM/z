//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Optional<T> : RuleExpr<Optional<T>,T>, IOptionRule
        where T : IRuleExpr
    {
        public Optional(T opt)
            : base(opt)
        {

        }

        public IRuleExpr Potential
            => Content;
        public override string Format()
            => text.bracket(Content.ToString());

        public static implicit operator Optional<T>(T value)
            => new Optional<T>(value);
    }
}