//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CmdPublic : AppCmdService<CmdPublic>
    {
        internal static CmdPublic factory(IWfRuntime wf)
        {
            var running = wf.Running($"Creating command providers");
            GlobalServices.Instance.Inject(wf.XedRuntime());
            var p = providers(wf);
            wf.Ran(running,$"Created {p.Length} command providers");
            return Cmd.service<CmdPublic>(wf, p.Unwrap());
        }
        
        public static CmdProviders providers(IWfRuntime wf)
        {
            var providers = new ICmdProvider[]{
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
                return new CmdProviders(_ => providers);
        }        
    }    
}