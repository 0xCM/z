//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICommutativeRing<S> : IRing<S>
        where S : ICommutativeRing<S>, new()
    {

    }
}