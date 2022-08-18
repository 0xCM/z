//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Characterizes a Gamma distribution
    /// </summary>
    /// <remarks>See https://en.wikipedia.org/wiki/Gamma_distribution</remarks>
    public readonly struct GammaSpec<T> : IDistributionSpec<T>
        where T : unmanaged
    {
        public readonly T Alpha;

        public readonly T Dx;

        public readonly T Beta;

        [MethodImpl(Inline)]
        public GammaSpec(T alpha, T dx, T beta)
        {
            Alpha = alpha;
            Dx = dx;
            Beta = beta;
        }

        /// <summary>
        /// Classifies the distribution spec
        /// </summary>
        public DistributionKind DistKind
            => DistributionKind.Gamma;
    }
}