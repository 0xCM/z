//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an action that that executes per machine rules
    /// </summary>
    public readonly struct FsmActionRule<S,A> : IFsmActionRule<S,A>
    {
        /// <summary>
        /// The state upon which the rule is predicated
        /// </summary>
        public S Source {get;}

        /// <summary>
        /// The action invoked
        /// </summary>
        public A Action {get;}

        /// <summary>
        /// The rule key
        /// </summary>
        public FsmActionRuleKey<S> Key {get;}

        /// <summary>
        /// The rule identifier
        /// </summary>
        public readonly int RuleId
        {
            [MethodImpl(Inline)]
            get => Key.Hash;
        }

        [MethodImpl(Inline)]
        public FsmActionRule(S source, A action)
        {
            Source = source;
            Action= action;
            Key = new FsmActionRuleKey<S>(source);
        }


        public readonly override string ToString()
            => $"({Source}) -> {Action}";

        /// <summary>
        /// Constructs a rule from a source/action pair
        /// </summary>
        /// <param name="src">The source state</param>
        /// <param name="action">The action</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="A">The action type</typeparam>
        [MethodImpl(Inline)]
        public static implicit operator FsmActionRule<S,A>((S src, A action) x)
            => new FsmActionRule<S,A>(x.src, x.action);
    }
}