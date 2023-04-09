//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class DevProjects : Stateless<DevProjects>
    {
        public static IEnumerable<FilePath> scripts(IDbArchive src)
            => src.Scoped("cmd").Files(FileKind.Cmd);

        public static void launch(IWfChannel channel, FolderPath root, Action<Process> start, Action<int> exit)
        {
            var context = Tooling.spec(root, EnvVars.Empty, start, exit);
            var workspaces = root.Files(FS.ext("code-workspace"));
            if(workspaces.IsNonEmpty)
                CodeLauncher.start(channel, root + workspaces[0].FileName, context).Wait();
            else
                CodeLauncher.start(channel, root, context).Wait();
        }
    }
}