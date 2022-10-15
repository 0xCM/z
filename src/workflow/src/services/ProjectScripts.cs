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
            return ProcExec.start(Channel, Cmd.cmd(path, CmdKind.Cmd, EmptyString));
        }

        public static Task<ExecToken> start(string project, string script, WfEmit channel)
        {
            var path = AppDb.ProjectLib(project).Scoped(scripts).Path(script, FileKind.Cmd);
            if(!path.Exists)
            {
                sys.@throw(AppMsg.FileMissing.Format(path));
            }
            var task =  ProcExec.start(channel, Cmd.cmd(path, CmdKind.Cmd, EmptyString));
            return task;
        }

        public Files List(CmdArgs args)
            => AppDb.ProjectLib(arg(args, 0).Value).Scoped(scripts).Files();
    }
}