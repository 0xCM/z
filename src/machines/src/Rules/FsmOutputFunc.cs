//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    /// <summary>
    /// Defines a partial state machine output function of the form
    /// (source : S, target : S) -> output : Option[O]
    /// for source/target pairs in the domain. If an input value (s1:S, s2:S)
    /// is not in the function domain, en empty option is returned
    /// </summary>
    [method: MethodImpl(Inline)]
    public class FsmOutputFunc<E,S,O>(IEnumerable<IFsmOutputRule<E, S, O>> Rules) : IFsmFunc
    {
        readonly Dictionary<Hash32,IFsmOutputRule<E,S,O>> RuleIndex = Rules.Select(x => (Fsm.outKey(x.Trigger, x.Source).Hash, x)).ToDictionary();

        /// <summary>
        /// /// Computes the output value, if any, for a specified source state and event
        /// </summary>
        /// <param name="trigger">The incoming event</param>
        /// <param name="source">The source state</param>
        [MethodImpl(Inline)]
        public Option<O> Output(E trigger, S source)
            => Rule(Fsm.outKey(trigger, source)).TryMap(r => r.Output);

        /// <summary>
        /// Searches for the output rule given a key
        /// </summary>
        /// <param name="key">The rule key</param>
        public Option<IFsmOutputRule<E,S,O>> Rule(IFsmRuleKey key)
        {
            if(RuleIndex.TryGetValue(key.Hash, out IFsmOutputRule<E,S,O> dst))
                return Option.some(dst);
            else
                return default;
        }

        [MethodImpl(Inline)]
        Option<IFsmRule> IFsmFunc.Rule(IFsmRuleKey key)
            => Rule(key).TryMap(r => r as IFsmRule);
    }
}