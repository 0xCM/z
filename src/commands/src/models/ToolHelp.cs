//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public record class ToolHelp
    {
        public @string ToolName;

        public @string DocName;
        
        public CmdLine HelpCmd;

        public @string Document; 

        public ToolHelp()
        {
            ToolName = @string.Empty;
            DocName = @string.Empty;
            HelpCmd = CmdLine.Empty;
            Document = @string.Empty;
        }

        public static ToolHelp Empty => new();
    }
}