//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class PolyDist
    {
        /// <summary>
        /// Constructs a Bernouli distribution given a specification and random source
        /// </summary>
        /// <param name="spec">A specification that characterizes the distribution</param>
        /// <param name="random">A (uniform) random source</param>
        /// <typeparam name="T">The sample element type</typeparam>
        public static BernoulliDist<T> Distribution<T>(this BernoulliSpec<T> spec, IPolyrand random)
            where T : unmanaged
                => new BernoulliDist<T>(random, spec);

        /// <summary>
        /// Produces a stream of random values conforming to a Bernoulli distribution
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="p">The probability of a given trial succeeding</param>
        public static BernoulliDist<T> Bernoulli<T>(this IPolyrand random, double p = 0.5)
            where T : unmanaged
                => new BernoulliSpec<T>(p).Distribution(random);
    }
}