//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    public class ProjectScripts : AppService<ProjectScripts>
    {        
        public Task<ExecToken> Start(CmdArgs args)
        {
            var project = arg(args, 0).Value;
            var script = arg(args, 1).Value;
            var path = AppDb.Service.ProjectLib(project).Scoped(scripts).Path(script, FileKind.Cmd);
            return ProcExec.launch(Channel, path, CmdArgs.Empty, ToolContext.Default);
        }

        public IEnumerable<FilePath> List(CmdArgs args)
            => AppDb.Service.ProjectLib(arg(args, 0).Value).Scoped(scripts).Files();
    }
}