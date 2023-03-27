//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        static ReadOnlySeq<IApiService> providers(IWfRuntime wf)
            => new IApiService[]{
                wf.WfCmd(),
                wf.EnvCmd(),
                wf.ImageCmd(),
                wf.ArchiveCmd(),
                wf.XedCmd(),
                wf.AsmCoreCmd(),
                wf.AsmDbCmd(),
                wf.AsmGenCmd(),
                wf.AsmFlowCmd(),
                wf.PbCmd(),
                wf.SdmCmd(),
                wf.XedToolCmd(),
                wf.IntelInxCmd(),
                wf.IntelCmd()
            };

        static int main(string[] args)
        {
            var result = 0;
            using var app = ApiServers.shell<App,AppCmd>(providers);
            try
            {
                GlobalServices.Instance.Inject(app.Wf.XedRuntime());
                app.Run();
            }
            catch(Exception e)
            {
                app.Channel.Error(e);
                result = -1;
            }
            //ProcessControl.Control().Dispose();
            return result;
        }

        public static int Main(params string[] args)
            => main(args);
    }

    sealed class AppCmd : WfAppCmd<AppCmd>
    {
        void CmdServices()
        {
            //var src = FS.path(ExecutingPart.Assembly.Location).FolderPath;
            
        }

    }
}