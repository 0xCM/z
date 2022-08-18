//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines state transition rule of the form (input : E, source : S) -> target : S
    /// </summary>
    /// <typeparam name="E">The input event type</typeparam>
    /// <typeparam name="S">The state type</typeparam>
    public readonly struct FsmTransitionRule<E,S> : IFsmTransitionRule<E,S>
    {
        /// <summary>
        /// The transition event trigger
        /// </summary>
        public E Trigger {get;}

        /// <summary>
        /// The state upon which the rule is predicated
        /// </summary>
        public S Source {get;}

        /// <summary>
        /// The target state
        /// </summary>
        public S Target {get;}

        /// <summary>
        /// The key that identifies the rule
        /// </summary>
        public IFsmRuleKey<E,S> Key {get;}

        [MethodImpl(Inline)]
        public FsmTransitionRule(E trigger, S source, S target)
        {
            Trigger = trigger;
            Source = source;
            Target = target;
            Key = Fsm.transitionKey(Trigger,Source);
        }

        /// <summary>
        /// The rule id as determined by the key
        /// </summary>
        public readonly int RuleId
        {
            [MethodImpl(Inline)]
            get => Key.Hash;
        }

        public override string ToString()
            => $"({Trigger},{Source}) -> {Target}";

        /// <summary>
        /// Constructs a state transition rule from an (input,source,target) triple
        /// </summary>
        /// <param name="input">The input event</param>
        /// <param name="source">The source state</param>
        /// <param name="target">The target state</param>
        [MethodImpl(Inline)]
        public static implicit operator FsmTransitionRule<E,S>((E input, S source, S target) x)
            => new FsmTransitionRule<E,S>(x.input, x.source, x.target);
    }
}