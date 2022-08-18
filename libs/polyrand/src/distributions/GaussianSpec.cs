//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static Numeric;

    /// <summary>
    /// Characterizes a Gaussian (normal) distribution
    /// </summary>
    /// <remarks>See https://en.wikipedia.org/wiki/Normal_distribution</remarks>
    /// <typeparam name="T">The sample value type</typeparam>
    public readonly struct GaussianSpec<T> : IDistributionSpec<T>
        where T : unmanaged
    {
        /// <summary>
        /// The mean of the distribtion that serves as the location parameter
        /// </summary>
        public readonly T Mean;

        /// <summary>
        /// The standard deviation
        /// </summary>
        public readonly T StdDev;

        [MethodImpl(Inline)]
        public GaussianSpec(T mean, T stddev)
        {
            Mean = mean;
            StdDev = stddev;
        }

        /// <summary>
        /// Defines a Gaussian distribution with specified mean and standard deviation
        /// </summary>
        /// <param name="mu">The distribution mean</param>
        /// <param name="sigma">The standard deviation</param>
        /// <typeparam name="T">The sample element type</typeparam>
        [MethodImpl(Inline)]
        public static GaussianSpec<T> Define(T mu, T sigma)
            => new GaussianSpec<T>(mu,sigma);

        public T Variance
        {
            [MethodImpl(Inline)]
            get
            {
                var sig = force<T,double>(StdDev);
                Require.invariant(sig != 0, () =>$"The invariant k := (sigma == 0) failed");
                return force<T>(sig*sig);
            }
        }

        public T Precision
        {
            [MethodImpl(Inline)]
            get
            {
                var sig = force<T,double>(StdDev);
                Require.invariant(sig != 0, () => $"The invariant k := (sigma == 0) failed");
                return force<T>(gmath.recip(sig*sig));
            }
        }

        /// <summary>
        /// Classifies the distribution spec
        /// </summary>
        public DistributionKind DistKind
            => DistributionKind.Gaussian;

        [MethodImpl(Inline)]
        public GaussianSpec<float> ToFloat32()
            => new GaussianSpec<float>(force<T,float>(Mean), force<T,float>(StdDev));

        [MethodImpl(Inline)]
        public GaussianSpec<double> ToFloat64()
            => new GaussianSpec<double>(force<T,double>(Mean), force<T,double>(StdDev));

        [MethodImpl(Inline)]
        public static implicit operator (T mu, T sigma)(GaussianSpec<T> spec)
            => (spec.Mean, spec.StdDev);

        [MethodImpl(Inline)]
        public static implicit operator GaussianSpec<T>((T mu, T sigma) x )
            => Define(x.mu, x.sigma);
    }
}