//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes semiring operations
        /// </summary>
        /// <typeparam name="T">The individual type</typeparam>
        public interface ISemiring<T> : IAdditiveMonoid<T>, IMultiplicativeMonoid<T>, IDistributive<T>
            where T : unmanaged
        {
            T MulAdd(T x, T y, T z);
        }
    }
}