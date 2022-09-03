//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILeftModule<R,G>  : IAdditiveGroup<G>
        where R : IRing<R>, new()
        where G : IAdditiveGroup<G>, new()
    {
        /// <summary>
        /// Effects scalar multiplication from the left
        /// </summary>
        /// <param name="r">The ring individual type, i.e., the scalar type</param>
        /// <param name="m">The group individual type</param>
        G LeftScale(R r);
    }

    public interface ILeftModule<S,R,G> : ILeftModule<R,G>
        where S : ILeftModule<S,R,G>, new()
        where R : ICommutativeRing<R>, new()
        where G : IAdditiveGroup<G>, new()
    {

    }
}