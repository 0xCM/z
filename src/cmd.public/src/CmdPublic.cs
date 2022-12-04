//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CmdPublic : WfAppCmd<CmdPublic>
    {
        public static IApiContext<C> context<C>(IWfRuntime wf)
            where C : IApiService<C>, new()
        {
            GlobalServices.Instance.Inject(wf.XedRuntime());
            return ApiServer.context<C>(wf, () => providers(wf));            
        }
        
        public static ReadOnlySeq<IApiCmdProvider> providers(IWfRuntime wf)
        {
            var providers = new IApiCmdProvider[]{
                wf.AncestryChecks(),
                wf.EnvCmd(),
                wf.AsmCoreCmd(),
                wf.AsmCmdSvc(),
                wf.AsmCheckCmd(),
                wf.CaptureCmd(),
                wf.AsmDbCmd(),
                wf.EcmaCmd(),
                wf.LlvmCmd(),
                wf.ArchiveCmd(),
                //wf.RoslynCmd(),
                wf.IntelInxCmd(),
                wf.Machines(),
                wf.ProjectCmd(),
                wf.ContextCmd(),
                wf.WfCmd(),
                wf.XedCmd(),
                //wf.XedChecks(),
                wf.BuildCmd(),
                wf.XedToolCmd(),
                wf.CalcChecker(),
                wf.TestCmd(),
                wf.AsmGenCmd(),
                wf.CsGenCmd(),
                wf.MemoryChecks(),
                wf.CgChecks(),
                wf.SdmCmd()
                };
                return providers;
        }        
    }    
}