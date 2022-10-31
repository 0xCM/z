//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class LlvmApp : AppCmdShell<LlvmApp>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
                wf.BuildCmd(),
                wf.LlvmCmd(),
                //wf.EcmaCmd(),
                wf.ProjectCmd()
            };

        public static void Main(params string[] args)
        {
            using var app = AppCmdShell.create<LlvmApp>(false, args);
            var context = WfServices.context<LlvmShellCmd>(app.Wf, () => providers(app.Wf));
            app.Commander = context.Commander;
            Env.cd(AppSettings.EnvRoot().Scoped("sdks/llvm").Root);
            app.Run(args);            
        }         
    }

    sealed class LlvmShellCmd : WfAppCmd<LlvmShellCmd>
    {

    }
}