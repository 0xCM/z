//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        public static int Main(params string[] args)
        {
            var result = 0;
            //using var app = ApiServers.shell<App,AppCmd>(providers);
            //using var wf = ApiServers.runtime(false);
            var wf = ApiServers.runtime(false);
            GlobalServices.Instance.Inject(wf.XedRuntime());
            using var app = ApiServers.shell(wf, args);
            try
            {
                app.Run();
            }
            catch(Exception e)
            {
                term.error(e);
                result = -1;
            }
            return result;
        }
        //{
            // using var app = ApiServers.shell<App>(args);  
            // app.Commander = context<AppShellCmd>(app.Wf).Commander;
            // app.Run();
        //}

        // public static IApiContext context<C>(IWfRuntime wf)
        //     where C : IApiService, new()
        // {
        //     GlobalServices.Instance.Inject(wf.XedRuntime());
        //     return ApiServers.context<C>(wf, () => providers(wf));            
        // }
        
        // public static ReadOnlySeq<IApiService> providers(IWfRuntime wf)
        // {
        //     var providers = new IApiService[]{
        //         wf.AncestryChecks(),
        //         wf.EnvCmd(),
        //         wf.AsmCoreCmd(),
        //         wf.AsmCmdSvc(),
        //         wf.CsGenCmd(),
        //         wf.CaptureCmd(),
        //         wf.AsmDbCmd(),
        //         wf.EcmaCmd(),
        //         wf.ArchiveCmd(),
        //         wf.IntelInxCmd(),
        //         wf.Machines(),
        //         wf.ImageCmd(),
        //         wf.WfCmd(),
        //         wf.XedCmd(),
        //         wf.XedToolCmd(),
        //         wf.CalcChecker(),
        //         wf.TestCmd(),
        //         wf.AsmGenCmd(),
        //         wf.MemoryChecks(),
        //         wf.SdmCmd()
        //         };
        //         return providers;
        // }        
 
    }

    sealed class AppShellCmd : WfAppCmd<AppShellCmd>
    {

    }
}