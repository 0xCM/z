//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfContext
    {
        IWfChannel Channel {get;}

        IWfRuntime Runtime {get;}
    }
}
