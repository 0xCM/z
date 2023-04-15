
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCmdSvc : WfSvc<ApiCmdSvc>, IApiService
    {                         
        public void RunCmd(string name)
        {
            CmdRunner.RunCommand(name);
        }
    }

    partial class XSvc
    {
        partial class ServiceCache
        {
            public ApiCmdSvc ApiCmd(IWfRuntime wf)
                => Service<ApiCmdSvc>(wf);
        }

        public static ApiCmdSvc ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);
    }
}