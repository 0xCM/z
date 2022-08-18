//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFiniteAbelianGroup<S,T> : IDiscreteAbelianGroup<S,T>, IDeferredSet<S,T>
        where S : IFiniteAbelianGroup<S,T>, new()
    {

    }
}