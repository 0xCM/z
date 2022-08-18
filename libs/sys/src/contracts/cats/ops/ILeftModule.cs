//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial struct Operational
    {
        /// <summary>
        /// Characterizes a left module over a commtative unital ring
        /// </summary>
        /// <typeparam name="G">The group individual type</typeparam>
        /// <typeparam name="R">The ring individual type</typeparam>
        public interface ILeftModule<R,G> : IAdditiveGroup<G>
            where R : unmanaged, ICommutativeRing<R>
            where G : unmanaged

        {
            /// <summary>
            /// Effects left scalar multiplication
            /// </summary>
            /// <param name="r">The ring individual type, i.e., the scalar type</param>
            /// <param name="m">The group individual type</param>
            G LeftScale(R r, G m);
        }
    }
}