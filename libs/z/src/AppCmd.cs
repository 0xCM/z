//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class AppCmd : AppCmdService<AppCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.ApiCmd(),
                wf.AncestryChecks(),
                wf.AsmCoreCmd(),
                wf.AsmCmdSvc(),
                wf.AsmChecks(),
                wf.CaptureCmd(),
                wf.AsmDbCmd(),
                wf.CliCmd(),
                wf.DbCmd(),
                wf.LlvmCmd(),
                wf.RoslynCmd(),
                wf.IntelInxCmd(),
                wf.Machines(),
                wf.ProjectCmd(),
                wf.RuntimeCmd(),
                wf.ToolCmd(),
                wf.WfCmd(),
                wf.RoslynCmd(),
                wf.XedCmd(),
                wf.XedChecks(),
                wf.BuildCmd(),
                wf.XedToolCmd(),
                wf.FsmCmd(),
                wf.CalcChecker(),
                wf.TestCmd(),
                wf.AsmGenCmd(),
                wf.SosCmd(),
                wf.CsGenCmd(),
                wf.MemoryChecks(),
                wf.CgChecks(),
                };

        public static AppCmd service(IWfRuntime wf)
        {
            ApiGlobals.Instance.Inject(wf.XedRuntime());
            var flow = wf.Running("Creating application host");
            var providers = AppCmd.providers(wf);
            var cmd = Cmd.service<AppCmd>(wf, providers);
            wf.Ran(flow, $"Created application host with {providers.Length} command providers");
            return cmd;
        }

        protected override void Initialized()
        {            
            LoadCatalog();
        }

        void LoadCatalog()
        {
            Emitter.Write($"Providers:{Providers.Count}");
            iter(Providers, p => Emitter.Row(p.GetType().DisplayName()));
        }

        void PrintAssemblies()
        {
            var src = ApiRuntime.colocated(ExecutingPart.Assembly);
            iter(src, a => Emitter.Row(FS.uri(a.Location)));
        }
    }    
}