//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct WfMsgSvc : IWfMsg
    {
        public IWfRuntime Wf {get;}

        public Type HostType {get;}

        public WfMsgSvc(IWfRuntime wf, Type host)
        {
            Wf = wf;
            HostType = host;
        }


        public void Dispose()
        {

        }
    }
}