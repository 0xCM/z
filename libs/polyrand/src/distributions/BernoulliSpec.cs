//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Characterizes a bernoulli distribution
    /// </summary>
    /// <typeparam name="T">The sample value type</typeparam>
    /// <remarks>See https://en.wikipedia.org/wiki/Bernoulli_distribution</remarks>
    public readonly struct BernoulliSpec<T> : IDistributionSpec<T>
        where T : unmanaged
    {
        /// <summary>
        /// Specifies a value within the unit interval [0,1] that represents the probability of success
        /// </summary>
        public readonly double Success;

        public DistributionKind DistKind
            => DistributionKind.Bernoulli;

        [MethodImpl(Inline)]
        public BernoulliSpec(double p)
            => Success = p;

        [MethodImpl(Inline)]
        public static implicit operator BernoulliSpec<T>(double p)
            => new BernoulliSpec<T>(p);

        [MethodImpl(Inline)]
        public static implicit operator double(BernoulliSpec<T> p)
            => p.Success;
    }
}