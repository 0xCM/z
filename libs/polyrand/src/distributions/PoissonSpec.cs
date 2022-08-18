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
    /// Characterizes a Poisson distribution
    /// </summary>
    /// <remarks>See https://en.wikipedia.org/wiki/Poisson_distribution</remarks>
    /// <typeparam name="T">The sample value type</typeparam>
    public readonly struct PoissonSpec<T> : IDistributionSpec<T>
        where T : unmanaged
    {
        /// <summary>
        /// Specifies the event frequency
        /// </summary>
        public readonly double Rate;

         /// <summary>
        /// Classifies the distribution spec
        /// </summary>
        public DistributionKind DistKind
            => DistributionKind.Poisson;

        [MethodImpl(Inline)]
        public PoissonSpec(double src)
        {
            Rate = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator PoissonSpec<T>(double src)
            => new PoissonSpec<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator double(PoissonSpec<T> src)
            => src.Rate;
   }
}