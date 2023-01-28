//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a key, predicated on input event and current state, identifies a transition rule
    /// </summary>
    public readonly struct FsmTransitionRuleKey<E,S> : IFsmRuleKey<E,S>
    {
        /// <summary>
        /// The source state
        /// </summary>
        public S Source {get;}

        /// <summary>
        /// The triggering event
        /// </summary>
        public E Trigger {get;}

        public Hash32 Hash {get;}

        [MethodImpl(Inline)]
        public FsmTransitionRuleKey(E input, S source)
        {
            Trigger = input;
            Source = source;
            Hash = HashCode.Combine(input,source);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RpOps.Tuple2, Source, Trigger);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FsmTransitionRuleKey<E,S>((E trigger, S source) x)
            => new FsmTransitionRuleKey<E,S>(x.trigger,x.source);
    }
}