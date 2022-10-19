//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.Shell)]
namespace Z0.Parts
{
    public sealed class Shell : Part<Shell>
    {
        [ModuleInitializer]
        internal static void Init()
        {
            NumRender.Service.RegisterFomatters();
        }
    }
}

namespace Z0
{
    [Free]
    sealed class App : AppCmdShell<App>
    {
        static AppShellCmd commands(IWfContext context)
        {
            var wf = context.Runtime;
            var running = wf.Running($"Creating command providers");
            var providers = new ICmdProvider[]{
                wf.WfCmd(),
                wf.BuildCmd(),
                wf.DbCmd() 
            };
            wf.Ran(running, $"Created {providers.Length} command providers");
            return AppCmd.service<AppShellCmd>(wf, providers);
        }

        static int main(string[] args)
        {
            var result = 0;
            using var app = AppShells.create<App>(false,args);
            var context = app.Context;
            var wf = context.Runtime;
            var channel = context.Channel;
            app.CmdService = commands(context);
            if(args.Length == 0)
                app.Run(sys.empty<string>());
            else
            {
                try
                {
                    
                }
                catch(Exception e)
                {
                    channel.Error(e);
                    result = -1;
                }
            }
            return result;
        }

        public static int Main(params string[] args)
            => main(args);

    }

    sealed class AppShellCmd : AppCmdService<AppShellCmd>
    {

    }
}