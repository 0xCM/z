//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
                wf.ArchiveCmd(),
                wf.MemCmd(),
                wf.Machines(),
                wf.ProjectCmd(),
                wf.RuntimeCmd(),
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

        public static AppCmd commands(IWfRuntime wf)
        {
            ApiGlobals.Instance.Inject(wf.XedRuntime());
            var flow = wf.Running("Creating application command providers");
            var commands = providers(wf);
            wf.Ran(flow);

            flow = wf.Running($"Creating application host with");
            var cmd = create(wf, commands);
            wf.Ran(flow, $"Created application host with {commands.Length} command providers");

            return cmd;
        }

        protected override void Initialized()
        {
            RunCmd("project", CmdArgs.create(new CmdArg[]{new CmdArg(EmptyString, "mc.models")}));
        }
    }
}