//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFiniteGroup<S,T> : IDiscreteGroup<S,T>
        where S : IFiniteGroup<S,T>, new()
    {


    }
}