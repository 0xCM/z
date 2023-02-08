//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a key for output rule indexing/lookup
    /// </summary>
    /// <typeparam name="S">The state type</typeparam>
    public readonly struct FsmOutputRuleKey<E,S> : IFsmRuleKey<E,S>
    {
        public E Trigger {get;}

        public S Source {get;}

        /// <summary>
        /// The invariant hash
        /// </summary>
        public Hash32 Hash {get;}

        [MethodImpl(Inline)]
        public FsmOutputRuleKey(E trigger, S target)
        {
            Trigger = trigger;
            Source = target;
            Hash = HashCode.Combine(trigger,target);
        }

        public override string ToString()
            => $"({Trigger}, {Source})";

        [MethodImpl(Inline)]
        public static implicit operator FsmOutputRuleKey<E,S>((E trigger, S source) x)
            => new FsmOutputRuleKey<E,S>(x.trigger, x.source);
    }
}