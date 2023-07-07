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
    public readonly record struct FsmOutputRuleKey<E,S> : IFsmRuleKey<E,S>
    {
        public  readonly E Trigger;

        public readonly S Source;

        [MethodImpl(Inline)]
        public FsmOutputRuleKey(E trigger, S target)
        {
            Trigger = trigger;
            Source = target;
        }

        /// <summary>
        /// The invariant hash
        /// </summary>
        public readonly Hash32 Hash
            => sys.hash(Trigger) | sys.hash(Source);

        E IFsmRuleKey<E, S>.Trigger
            => Trigger;

        S IFsmRuleKey<E, S>.Source
            => Source;

        public override string ToString()
            => $"({Trigger}, {Source})";

        [MethodImpl(Inline)]
        public static implicit operator FsmOutputRuleKey<E,S>((E trigger, S source) x)
            => new (x.trigger, x.source);
    }
}