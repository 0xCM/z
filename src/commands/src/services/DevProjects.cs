//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class DevProjects : Stateless<DevProjects>
    {
        public static Task<ExecToken> exec(IWfChannel channel, CmdArgs args)
        {
            var path = AppDb.Service.ProjectLib(args[0]).Scoped("cmd").Path(args[1], FileKind.Cmd);
            return ProcExec.launch(channel, path, CmdArgs.Empty, ToolContext.Default);
        }

        public static IEnumerable<FilePath> scripts(IDbArchive src)
            => src.Scoped("cmd").Files(FileKind.Cmd);

        public static ExecToken shell(IWfChannel channel, CmdArgs args)
        {
            var profile = args[0].Value;
            var cwd = args.Count > 1 ? FS.dir(args[1]) : Env.cd();
            return shell(channel, profile, CmdArgs.Empty, cwd);  
        }

        [Op]
        public static ExecToken shell(IWfChannel channel, string profile, CmdArgs args, FolderPath cwd)
        {
            var flow = channel.Running($"Launching {profile} shell");
            var psi = new ProcessStartInfo
            {
                FileName = @"d:\tools\wt\wt.exe",
                CreateNoWindow = false,
                UseShellExecute = false,
                Arguments = $"nt --profile {profile} -d {cwd}",
                RedirectStandardError = false,
                RedirectStandardOutput = false,
                RedirectStandardInput = false,
            };
            var process = sys.process(psi);
            var result = process.Start();
            var token = ExecToken.Empty;
            if(!result)
                channel.Error("Process creation failed");
            else
                token = channel.Ran(flow, $"Launched {profile} shell: {process.Id}");
            return token;
        }

        public static void launch(IWfChannel channel, FolderPath root, Action<Process> start, Action<int> exit)
        {
            var context = ProcExec.context(root, EnvVars.Empty, start, exit);
            var workspaces = root.Files(FS.ext("code-workspace"));
            if(workspaces.IsNonEmpty)
                CodeLauncher.start(channel, root + workspaces[0].FileName, context).Wait();
            else
                CodeLauncher.start(channel, root, context).Wait();

        }

    }
}