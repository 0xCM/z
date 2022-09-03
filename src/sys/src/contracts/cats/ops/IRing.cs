//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a (unital) ring
        /// </summary>
        public interface IRing<T> : IAdditiveGroup<T>, IMultiplicativeMonoid<T>, IDistributive<T>
            where T : unmanaged
        {

        }
    }
}