//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct CmdFieldRow
    {
        const string TableId = "api.commands";

        [Render(22)]
        public ApiCmdRoute Route;

        [Render(22)]
        public @string CmdType;

        [Render(12)]
        public ushort Index;

        [Render(36)]
        public @string Name;

        [Render(48)]
        public @string DataType;

        [Render(32)]
        public @string Expression;
    }    
}