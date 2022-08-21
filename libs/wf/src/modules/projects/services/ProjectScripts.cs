//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProjectScripts : WfSvc<ProjectScripts>
    {
        public Task<ExecToken> Start(CmdArgs spec)
        {
            var project = arg(spec, 0).Value;
            var script = arg(spec, 1).Value;
            var path = AppDb.ProjectLib(project).Scoped(scripts).Path(script,FileKind.Cmd);
            return CmdScripts.start(Cmd.cmd(path, CmdKind.Cmd, EmptyString), Emitter);
        }

        public FS.Files List(CmdArgs args)
        {
            return AppDb.ProjectLib(arg(args, 0).Value).Scoped(scripts).Files();
        }
    }
}