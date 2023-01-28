//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies an action rule for lookup purposes
    /// </summary>
    /// <typeparam name="S">The state type</typeparam>
    public readonly struct FsmActionRuleKey<S> : IFsmRuleKey
    {
        public Hash32 Hash {get;}

        public S Source {get;}

        [MethodImpl(Inline)]
        public FsmActionRuleKey(S source)
        {
            Source = source;
            Hash = source.GetHashCode();
        }

        public readonly override string ToString()
            => $"({Source})";

        [MethodImpl(Inline)]
        public static implicit operator FsmActionRuleKey<S>(S source)
            => new FsmActionRuleKey<S>(source);
    }
}