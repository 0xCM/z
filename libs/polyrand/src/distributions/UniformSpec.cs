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
    /// Characterizes a uniform distribution
    /// </summary>
    /// <typeparam name="T">The sample value type</typeparam>
    /// <remarks>See https://en.wikipedia.org/wiki/Uniform_distribution</remarks>
    public readonly struct UniformSpec<T> : IDistributionSpec<UniformSpec<T>,T>
        where T : unmanaged
    {
        /// <summary>
        /// The lower bound
        /// </summary>
        public readonly T Min;

        /// <summary>
        /// The upper bound
        /// </summary>
        public readonly T Max;

        [MethodImpl(Inline)]
        public UniformSpec(T min, T max)
        {
            Min = min;
            Max = max;
        }

        [MethodImpl(Inline)]
        public UniformSpec(Interval<T> domain)
        {
            Min = domain.Left;
            Max = domain.Right;
        }

        /// <summary>
        /// Classifies the distribution
        /// </summary>
        public DistributionKind DistKind
            => DistributionKind.Uniform;

        [MethodImpl(Inline)]
        public UniformSpec<int> ToInt32()
            => new UniformSpec<int>(Numeric.force<T,int>(Min), Numeric.force<T,int>(Max));

        [MethodImpl(Inline)]
        public UniformSpec<float> ToFloat32()
            => new UniformSpec<float>(Numeric.force<T,float>(Min), Numeric.force<T,float>(Max));

        [MethodImpl(Inline)]
        public UniformSpec<double> ToFloat64()
            => new UniformSpec<double>(Numeric.force<T,double>(Min), Numeric.force<T,double>(Max));

        [MethodImpl(Inline)]
        public static implicit operator (T min, T max)(in UniformSpec<T> spec)
            => (spec.Min, spec.Max);

        [MethodImpl(Inline)]
        public static implicit operator UniformSpec<T>((T min, T max) x )
            => new UniformSpec<T>(x.min, x.max);

        [MethodImpl(Inline)]
        public static implicit operator UniformSpec<T>(in Interval<T> x)
            => new UniformSpec<T>(x.Left, x.Right);

        [MethodImpl(Inline)]
        public static implicit operator Interval<T>(in UniformSpec<T> x)
            => new UniformSpec<T>(x.Min, x.Max);
   }
}