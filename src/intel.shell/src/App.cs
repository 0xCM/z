//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        // static ReadOnlySeq<IApiService> providers(IWfRuntime wf)
        //     => new IApiService[]{
        //         wf.WfCmd(),
        //         wf.EnvCmd(),
        //         wf.ImageCmd(),
        //         wf.ArchiveCmd(),
        //         wf.XedCmd(),
        //         wf.AsmCoreCmd(),
        //         wf.AsmDbCmd(),
        //         wf.AsmGenCmd(),
        //         wf.AsmFlowCmd(),
        //         wf.PbCmd(),
        //         wf.SdmCmd(),
        //         wf.XedToolCmd(),
        //         wf.IntelInxCmd(),
        //         wf.IntelCmd()
        //     };

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
    }

    sealed class AppCmd : WfAppCmd<AppCmd>
    {
        void CmdServices()
        {
            //var src = FS.path(ExecutingPart.Assembly.Location).FolderPath;
            
        }

    }
}