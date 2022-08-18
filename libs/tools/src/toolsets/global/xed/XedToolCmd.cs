//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDomain;

    [StructLayout(LayoutKind.Sequential, Pack=1), Cmd(CmdName)]
    public struct XedToolCmdSpec : IToolFlowCmd<XedToolCmdSpec>
    {
        const string CmdName = "xedtool.cmd";

        [CmdArg("<src>")]
        public FS.FilePath Source;

        [CmdArg("<dst>")]
        public FS.FilePath Target;

        [CmdArg("-{0}")]
        public InputKind InputKind;

        [CmdArg("-v {0}")]
        public Verbosity Verbosity;

        [CmdArg("-{0}")]
        public Mode Mode;

        FS.FilePath IFlowCmd<FS.FilePath, FS.FilePath>.Source
            => Source;

        FS.FilePath IFlowCmd<FS.FilePath, FS.FilePath>.Target
            => Target;
    }
}