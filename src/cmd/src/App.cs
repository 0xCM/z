//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class App : AppCmdShell<App>
    {   
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.ApiCmd(),
                wf.AncestryChecks(),
                wf.AsmCoreCmd(),
                wf.AsmCmdSvc(),
                //wf.AsmChecks(),
                wf.CaptureCmd(),
                wf.AsmDbCmd(),
                wf.EcmaCmd(),
                wf.DbCmd(),
                wf.LlvmCmd(),
                wf.RoslynCmd(),
                wf.IntelInxCmd(),
                wf.Machines(),
                wf.ProjectCmd(),
                wf.RuntimeCmd(),
                wf.WfCmd(),
                wf.RoslynCmd(),
                wf.XedCmd(),
                //wf.XedChecks(),
                wf.BuildCmd(),
                wf.XedToolCmd(),
                wf.CalcChecker(),
                wf.TestCmd(),
                wf.AsmGenCmd(),
                wf.SosCmd(),
                wf.CsGenCmd(),
                wf.MemoryChecks(),
                wf.CgChecks(),
                };

        public static void Main(params string[] args)
        {
            using var app = AppShells.create<App>(false, args);            
            var wf = app.Wf;
            var running = wf.Running($"Creating command providers");
            GlobalServices.Instance.Inject(wf.XedRuntime());
            app.CmdService = Cmd.service<AppShellCmd>(wf, providers(wf));
            app.Run(args);            
        }
    }

    sealed class AppShellCmd : AppCmdService<AppShellCmd>
    {

    }    
}