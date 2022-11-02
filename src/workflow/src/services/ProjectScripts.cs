//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProjectScripts : WfSvc<ProjectScripts>
    {        
        public Task<ExecToken> Start(CmdArgs args)
        {
            var project = arg(args, 0).Value;
            var script = arg(args, 1).Value;
            var path = AppDb.ProjectLib(project).Scoped(scripts).Path(script, FileKind.Cmd);
            return ProcessControl.start(Channel, Cmd.cmd(path, CmdKind.Cmd, EmptyString));
        }

        public Files List(CmdArgs args)
            => AppDb.ProjectLib(arg(args, 0).Value).Scoped(scripts).Files();
    }
}