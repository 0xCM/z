//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
 
    /// <summary>
    /// Defines a set of rules that define actions associated with state Exit
    /// </summary>
    public class FsmExitFunc<S,A>(IEnumerable<IFsmActionRule<A>> rules) : IFsmFunc
    {
        readonly Dictionary<int, IFsmActionRule<A>> RuleIndex = rules.Select(rule => (rule.RuleId, rule)).ToDictionary();

        public Option<A> Eval(S source)
            => Rule(Fsm.exitKey(source)).TryMap(r => r.Action);

        public Option<IFsmActionRule<A>> Rule(IFsmRuleKey key)
        {
            if(RuleIndex.TryGetValue(key.Hash, out IFsmActionRule<A> dst))
                return Option.some(dst);
            else
                return default;
        }

        Option<IFsmRule> IFsmFunc.Rule(IFsmRuleKey key)
            => Rule(key).TryMap(r => r as IFsmRule);
    }
}