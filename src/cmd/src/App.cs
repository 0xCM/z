//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        public static void Main(params string[] args)
        {
            using var app = ApiServers.shell<App>(false, args);            
            app.Commander = context<AppShellCmd>(app.Wf).Commander;
            app.Run(args);
        }


        public static IApiContext context<C>(IWfRuntime wf)
            where C : IApiService, new()
        {
            GlobalServices.Instance.Inject(wf.XedRuntime());
            return ApiServers.context<C>(wf, () => providers(wf));            
        }
        
        public static ReadOnlySeq<IApiCmdProvider> providers(IWfRuntime wf)
        {
            var providers = new IApiCmdProvider[]{
                wf.AncestryChecks(),
                wf.EnvCmd(),
                wf.AsmCoreCmd(),
                wf.AsmCmdSvc(),
                //wf.AsmCheckCmd(),
                wf.CaptureCmd(),
                wf.AsmDbCmd(),
                wf.EcmaCmd(),
                wf.LlvmCmd(),
                wf.ArchiveCmd(),
                wf.ClrCmd(),
                wf.IntelInxCmd(),
                wf.Machines(),
                wf.ProjectCmd(),
                wf.ImageCmd(),
                wf.WfCmd(),
                wf.XedCmd(),
                wf.BuildCmd(),
                wf.XedToolCmd(),
                wf.CalcChecker(),
                wf.TestCmd(),
                wf.AsmGenCmd(),
                wf.MemoryChecks(),
                wf.SdmCmd()
                };
                return providers;
        }        
 
    }

    sealed class AppShellCmd : WfAppCmd<AppShellCmd>
    {

    }
}