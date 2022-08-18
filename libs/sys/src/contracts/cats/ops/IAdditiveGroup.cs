//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes additive/abelian group operations
        /// </summary>
        public interface IAdditiveGroup<T> : IGroup<T>, IAdditiveMonoid<T>, INegatable<T>
        {

        }
    }
}