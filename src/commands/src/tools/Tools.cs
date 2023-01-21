//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class Tools
    {
        public static Task<ExecToken> start(IWfChannel channel, CmdArgs args)
        {
            var tool = FS.path(args[0]);
            var toolname = tool.FileName.WithoutExtension.Format();
            var running = channel.Running($"Executing '{args}'");
            var dst = AppDb.Service.DbTargets($"tools/{toolname}").Path(tool.FileName.ChangeExtension(FileKind.Help));
            return ProcessLauncher.redirect(channel, args, dst);
        }
        
        public static Task<ExecToken> vscode<T>(IWfChannel channel, T target, ToolContext? context = null)
            => ProcessLauncher.launch(channel, FS.path("code.exe"), Cmd.args(target), context);

        public static Task<ExecToken> devenv<T>(IWfChannel channel, T target, ToolContext? context = null)
            => ProcessLauncher.launch(channel, FS.path("devenv.exe"), Cmd.args(target), context);
    }
}