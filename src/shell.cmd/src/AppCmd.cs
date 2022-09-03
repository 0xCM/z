//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppShellCmd : AppCmdService<AppShellCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.ProjectCmd(),
                wf.WfCmd(),
                wf.MemCmd(),
                wf.CaptureCmd(),
                wf.AsmCoreCmd(),
                wf.LlvmCmd(),
                wf.XedToolCmd(),
                wf.Machines(),
                wf.ApiCmd(),
                wf.RoslynCmd(),
                wf.AsmCmdSvc(),
                wf.XedCmd(),
                wf.XedChecks(),
                wf.CliCmd(),
                wf.RuntimeCmd(),
                wf.AsmChecks(),
                wf.CheckRunner(),
                wf.IntelInxCmd(),
                wf.ToolBoxCmd(),
                };

        public static AppShellCmd commands(IWfRuntime wf)
        {
            var xed = ApiGlobals.Instance.Inject(wf.XedRuntime());
            return create(wf, providers(wf));
        }

        protected override void Initialized()
        {
            RunCmd("project", CmdArgs.create(new CmdArg[]{new CmdArg(EmptyString, "mc.models")}));
        }
    }
}