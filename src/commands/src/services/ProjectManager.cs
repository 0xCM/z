//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProjectManager : WfSvc<ProjectManager>
    {
        public void Launch(FolderPath root, Action<Process> start, Action<int> exit)
        {
            var context = ProcExec.context(root, EnvVars.Empty, start, exit);
            var workspaces = root.Files(FS.ext("code-workspace"));
            if(workspaces.IsNonEmpty)
                CodeLauncher.start(Channel, root + workspaces[0].FileName, context).Wait();
            else
                CodeLauncher.start(Channel, root, context).Wait();
        }
    }
}