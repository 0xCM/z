//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppServiceUtilities
    {
        IWfRuntime Wf {get;}

        WfHost Host {get;}
    }
}