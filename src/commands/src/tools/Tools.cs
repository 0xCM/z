//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class Tools
    {
        public static Task<ExecToken> vscode<T>(IWfChannel channel, T target, CmdContext? context = null)
            => ProcessLauncher.launch(channel, FS.path("code.exe"), Cmd.args(target), context);

        public static Task<ExecToken> devenv<T>(IWfChannel channel, T target, CmdContext? context = null)
            => ProcessLauncher.launch(channel, FS.path("devenv.exe"), Cmd.args(target), context);

        public static ToolKey key(uint seq, FileName name)
            => new (seq,name);               
    }
}