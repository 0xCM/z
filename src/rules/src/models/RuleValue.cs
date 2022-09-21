//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class RuleValue : RuleValue<@string>
    {
        public RuleValue(string src, bool terminal = false)
            : base(src, terminal)
        {

        }

        public static implicit operator RuleValue(string src)
            => new RuleValue(src);

        public static implicit operator RuleValue(@string src)
            => new RuleValue(src);
    }
}