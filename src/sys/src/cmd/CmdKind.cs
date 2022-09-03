//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies concrete command types
    /// </summary>
    [SymSource(cmd)]
    public enum CmdKind : byte
    {        
        None,

        [Symbol("app", "Classifies commands that are routed via an application shell")]
        App,

        [Symbol("tool", "Classifies commands that are routed via the toolbase api")]
        Tool,

        [Symbol("ws", "Classifies commands that are routed via the workspace api")]
        Ws,

        [Symbol("cmd", "Classifies commands that are routed via cmd.exe")]
        Cmd,

        [Symbol("pwsh", "Classifies commands that are routed via pwsh.exe")]
        Pwsh,

        [Symbol("wsl", "Classifies commands that are routed via wsl.exe")]
        Wsl,
    }
}

namespace global
{
    partial class sys
    {
        public static string format(CmdKind src)
            => src switch{
                CmdKind.App => "app",
                CmdKind.Tool => "tool",
                CmdKind.Ws => "ws",
                CmdKind.Cmd => "cmd",
                CmdKind.Pwsh => "pwsh",
                CmdKind.Wsl => "wsl",
                _ => ""
            };
    }
}