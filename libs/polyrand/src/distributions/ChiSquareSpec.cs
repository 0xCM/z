//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Characterizes a bernouli distribution
    /// </summary>
    /// <typeparam name="T">The sample value type</typeparam>
    public readonly struct ChiSquareSpec<T> : IDistributionSpec<T>
        where T : unmanaged
    {
        [MethodImpl(Inline)]
        public ChiSquareSpec(int freedom)
        {
            Freedom = freedom;
        }

        /// <summary>
        /// The number of degrees of freedom
        /// </summary>
        public readonly int Freedom;

        /// <summary>
        /// Classifies the distribution spec
        /// </summary>
        public DistributionKind DistKind
            => DistributionKind.Chi2;

        [MethodImpl(Inline)]
        public static implicit operator ChiSquareSpec<T>(int freedom)
            => new ChiSquareSpec<T>(freedom);

        [MethodImpl(Inline)]
        public static implicit operator int(ChiSquareSpec<T> src)
            => src.Freedom;
    }
}