//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedTool;

    [StructLayout(LayoutKind.Sequential, Pack=1), Cmd(CmdName)]
    public struct XedToolCmdSpec
    {
        const string CmdName = "xedtool.cmd";

        [CmdArg("<src>")]
        public FilePath Source;

        [CmdArg("<dst>")]
        public FilePath Target;

        [CmdArg("-{0}")]
        public InputKind InputKind;

        [CmdArg("-v {0}")]
        public Verbosity Verbosity;

        [CmdArg("-{0}")]
        public string Mode;
    }
}