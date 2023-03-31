//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    sealed class DevFlows : WfAppCmd<DevFlows>
    {    
        public static void develop(IWfChannel channel, CmdArgs args)
            => CodeLauncher.create(channel).Launch(args, launched => {});
        
        public static Task<ExecToken> scripts(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                var src = FS.dir(args[0]);
                var flow = channel.Running($"Listing {src} scripts");
                iter(DevProjects.scripts(src.DbArchive()), path => channel.Write(path.ToUri()));
                return channel.Ran(flow, $"Listed {src} scripts");
            }
            return sys.start(Run);
        }

        public static Task<ExecToken> exec(IWfChannel channel, CmdArgs args)
        {
            var path = AppDb.Service.ProjectLib(args[0]).Scoped("cmd").Path(args[1], FileKind.Cmd);
            return ToolExec.run(channel, path, CmdArgs.Empty, ToolExecSpec.Default);
        }

        public static Task<ExecToken> shell(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                var profile = args[0].Value;
                var cwd = args.Count > 1 ? FS.dir(args[1]) : Env.cd();
                return DevProjects.shell(channel, profile, cwd);  
            }
            return sys.start(Run);
        }

        [CmdOp("dev/shell")]
        void LaunchShell(CmdArgs args)
            => shell(Channel,args);

        [CmdOp("develop")]
        void Develop(CmdArgs args)
            => develop(Channel, args);

        [CmdOp("dev/scripts/list")]
        void Scripts(CmdArgs args)
            => scripts(Channel,args);

        [CmdOp("dev/scripts/exec")]
        void Script(CmdArgs args)
            => exec(Channel,args);
    }
}