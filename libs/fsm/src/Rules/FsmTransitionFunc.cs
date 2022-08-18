//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    /// <summary>
    /// Encapsulates the set of all rules (input : E, source : S) -> target : S that define state machine transitions
    /// </summary>
    public class FsmTransitionFunc<E,S> : IFsmFunc<E,S>
    {
        readonly Dictionary<int,IFsmTransitionRule<E,S>> Index;

        public FsmTransitionFunc(IEnumerable<IFsmTransitionRule<E,S>> rules)
            => Index = rules.Select(x => (Fsm.transitionKey(x.Trigger,x.Source).Hash, x)).ToDictionary();

        public FsmTransitionFunc(IEnumerable<FsmTransitionRule<E,S>> rules)
            => Index = rules.Select(x => (Fsm.transitionKey(x.Trigger,x.Source).Hash, x as IFsmTransitionRule<E,S>)).ToDictionary();

        [MethodImpl(Inline)]
        public Option<S> Eval(E input, S source)
            => Rule(Fsm.transitionKey(input,source)).TryMap(r => r.Target);

        public Option<IFsmTransitionRule<E,S>> Rule(IFsmRuleKey key)
        {
            if(Index.TryGetValue(key.Hash, out IFsmTransitionRule<E,S> dst))
                return Option.some(dst);
            else
                return default;
        }

        Option<IFsmRule> IFsmFunc.Rule(IFsmRuleKey key)
            => Rule(key).TryMap(r => r as IFsmRule);

        /// <summary>
        /// Specifies the set of events that can effect a transition
        /// </summary>
        public IEnumerable<E> Triggers
            => Index.Values.Select(x => x.Trigger).Distinct();
    }
}