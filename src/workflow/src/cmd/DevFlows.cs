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
            return Tooling.start(channel, path, CmdArgs.Empty, ToolCmdSpec.Default);
        }

        [CmdOp("dev/shell")]
        void LaunchShell(CmdArgs args)
            => Tooling.shell(Channel,args);

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