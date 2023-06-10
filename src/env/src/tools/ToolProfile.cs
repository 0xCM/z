//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct ToolProfile
    {
        const string TableId = "tool.profiles";

        [Render(32)]
        public @string ToolName;

        [Render(16)]
        public string Modifier;

        [Render(32)]
        public CmdArg HelpCmd;

        [Render(32)]
        public @string Membership;

        [Render(1)]
        public FilePath Executable;
    }
}