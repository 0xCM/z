//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Generic;

    /// <summary>
    /// Realizes a Bernoulli distribution
    /// </summary>
    /// <typeparam name="T">The sample element type</typeparam>
    public class BernoulliDist<T> : Distribution<BernoulliSpec<T>,T>
        where T : unmanaged
    {
        static T Zero => default;

        static T One => core.one<T>();

        public BernoulliDist(IPolyrand random, BernoulliSpec<T> spec)
            : base(random, spec)
        {
        }

        public override IEnumerable<T> Sample()
        {
            while(true)
            {
                var success = fmath.lt(Polyrand.Next<double>(), Spec.Success) ? One : Zero;
                yield return success;
            }
        }
    }
}