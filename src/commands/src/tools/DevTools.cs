//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
 
    public class DevTools
    {
        public static Task<ExecToken> vscode<T>(IWfChannel channel, T target)
            => CmdRunner.start(channel, FS.path("code.exe"), Cmd.args(target));

        public static Task<ExecToken> devenv<T>(IWfChannel channel, T target)
            => CmdRunner.start(channel, FS.path("devenv.exe"), Cmd.args(target));
    }
}