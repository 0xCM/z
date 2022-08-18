
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Characterizes a Cauchy distribution
    /// </summary>
    /// <remarks>See https://en.wikipedia.org/wiki/Cauchy_distribution</remarks>
    public readonly struct CauchySpec<T> : IDistributionSpec<T>
        where T : unmanaged
    {
        /// <summary>
        /// The distribution mean
        /// </summary>
        public readonly T Location;

        /// <summary>
        /// The distribution scale
        /// </summary>
        public readonly T Scale;

        /// <summary>
        /// Classifies the distribution spec
        /// </summary>
        public DistributionKind DistKind
            => DistributionKind.Cauchy;

        [MethodImpl(Inline)]
        public CauchySpec(T loc, T scale)
        {
            Location = loc;
            Scale = scale;
        }

        [MethodImpl(Inline)]
        public static implicit operator (T loc, T scale)(CauchySpec<T> spec)
            => (spec.Location, spec.Scale);

        [MethodImpl(Inline)]
        public static implicit operator CauchySpec<T>((T loc, T scale) x)
            => new CauchySpec<T>(x.loc,x.scale);
    }
}