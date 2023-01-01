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
        public CmdRoute Route;

        [Render(22)]
        public @string CmdType;

        [Render(12)]
        public byte Index;

        [Render(36)]
        public @string Name;

        [Render(48)]
        public @string DataType;

        [Render(32)]
        public @string Expression;

        [Render(1)]
        public @string DefaultValue;
    }    
}