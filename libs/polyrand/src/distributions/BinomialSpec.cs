//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Characterizes a binomial distribution
    /// </summary>
    /// <typeparam name="T">The (integral) sample value type</typeparam>
    /// <remarks>See https://en.wikipedia.org/wiki/Binomial_distribution</remarks>
    public readonly struct BinomialSpec<T> : IDistributionSpec<T>
        where T : unmanaged
    {
        public readonly T Trials;

        public readonly double Success;

         /// <summary>
        /// Classifies the distribution spec
        /// </summary>
        public DistributionKind DistKind
            => DistributionKind.Binomial;

        [MethodImpl(Inline)]
        public BinomialSpec(T n, double p)
        {
            Trials = n;
            Success = p;
        }

        [MethodImpl(Inline)]
        public static implicit operator (T n, double p)(BinomialSpec<T> spec)
            => (spec.Trials, spec.Success);

        [MethodImpl(Inline)]
        public static implicit operator BinomialSpec<T>((T n, double p) spec)
            => (spec.n, spec.p);
    }
}