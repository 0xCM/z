//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
        public class ChoiceRule : ChoiceRule<RuleValue>
        {
            public ChoiceRule(Index<RuleValue> src)
                : base(src)
            {

            }
        }
    }
}