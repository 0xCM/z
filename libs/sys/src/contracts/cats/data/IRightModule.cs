//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRightModule<G,R>  : IAdditiveGroup<G>
        where R : IRing<R>, new()
        where G : IAdditiveGroup<G>, new()
    {
        /// <summary>
        /// Effects scalar multiplication from the right
        /// </summary>
        /// <param name="r">The ring individual type, i.e., the scalar type</param>
        /// <param name="m">The group individual type</param>
        G RightScale(R r);
    }

    public interface IRightModule<S,G,R> : IRightModule<G,R>
        where S : IRightModule<S,G,R>, new()
        where R : ICommutativeRing<R>, new()
        where G : unmanaged, IAdditiveGroup<G>
    {

    }

}