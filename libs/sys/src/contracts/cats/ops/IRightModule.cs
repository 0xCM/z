//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial struct Operational
    {
        /// <summary>
        /// Characterizes a right module over a commtative unital ring
        /// </summary>
        /// <typeparam name="G">The group individual type</typeparam>
        /// <typeparam name="R">The ring individual type</typeparam>
        public interface IRightModule<G,R> : IAdditiveGroup<G>
            where R : unmanaged, ICommutativeRing<R>
            where G : unmanaged
        {
            /// <summary>
            /// Effects right scalar multiplication
            /// </summary>
            /// <param name="m">The group individual type</param>
            /// <param name="r">The ring individual type, i.e., the scalar type</param>
            G RightScale(G m, R r);
        }
    }
}