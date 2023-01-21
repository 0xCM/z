//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Commands
{
    [Cmd(CmdName)]
    public record class LaunchDevShell : Command<LaunchDevShell>
    {
        public const string CmdName = "devshell";

        [CmdArg("cwd")]
        public FilePath Cwd;

        [CmdArg("app")]
        public FilePath App;

        [CmdArg("cfg")]
        public FilePath Cfg;

        public LaunchDevShell()
        {
            Cwd = FilePath.Empty;
            App = FS.path("wt.exe");
            Cfg = FilePath.Empty;
        }
    }
}
