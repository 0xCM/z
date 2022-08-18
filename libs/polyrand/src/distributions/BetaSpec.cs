//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Characterizes a beta distribution
    /// </summary>
    /// <typeparam name="T">The sample value type</typeparam>
    /// <remarks>See https://en.wikipedia.org/wiki/Beta_distribution</remarks>
    public readonly struct BetaSpec<T> :  IDistributionSpec<T>
        where T : unmanaged
    {
        public readonly T Alpha;

        public readonly T Beta;

        [MethodImpl(Inline)]
        public BetaSpec(T alpha, T beta)
        {
            Alpha = alpha;
            Beta = beta;
        }

        /// <summary>
        /// Classifies the distribution spec
        /// </summary>
        public DistributionKind DistKind
            => DistributionKind.Beta;

        [MethodImpl(Inline)]
        public static implicit operator (T alpha, T beta)(BetaSpec<T> spec)
            => (spec.Alpha, spec.Beta);

        [MethodImpl(Inline)]
        public static implicit operator BetaSpec<T>((T alpha, T beta) x )
            => new BetaSpec<T>(x.alpha, x.beta);
    }
}