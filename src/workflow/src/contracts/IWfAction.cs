//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfAction
    {

    }
    
    public interface IWfAction<A> : IWfAction
        where A : IWfAction<A>, new()
    {

    }
}