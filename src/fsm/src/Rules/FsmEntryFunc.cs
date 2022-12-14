//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    /// <summary>
    /// Defines a set of rules that define actions associated with state entry
    /// </summary>
    public readonly struct FsmEntryFunc<S,A> : IFsmFunc
    {
        readonly Dictionary<int, IFsmActionRule<A>> RuleIndex;

        public FsmEntryFunc(IEnumerable<IFsmActionRule<A>> rules)
            => RuleIndex = rules.Select(rule => (rule.RuleId, rule)).ToDictionary();

        public Option<A> Eval(S source)
            => Rule(Fsm.entryKey(source)).TryMap(r => r.Action);

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