//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
    public class RuleValue<T> : RuleExpr<RuleValue<T>,T>
    {
        public RuleValue(T src, bool terminal = false)
            : base(src)
        {
            IsTerminal = terminal;
        }

        public override string Format()
            => Content.ToString();

        [MethodImpl(Inline)]
        public static implicit operator RuleValue<T>(T src)
            => new RuleValue<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T (RuleValue<T> src)
            => src.Content;
    }
    }


}