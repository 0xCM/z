//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDiscreteAbelianGroup<S,T> : IAdditiveGroup<S,T>, IDeferredSet<S,T>
        where S : IDiscreteAbelianGroup<S,T>, new()
    {

    }
}