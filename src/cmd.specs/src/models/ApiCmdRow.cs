//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct ApiCmdRow
    {
        const string TableId = "api.commands.typed";

        [Render(22)]
        public @string CmdName;

        [Render(22)]
        public string CmdType;

        [Render(12)]
        public byte FieldIndex;

        [Render(36)]
        public string FieldName;

        [Render(48)]
        public string DataType;

        [Render(32)]
        public string Expression;

        [Render(1)]
        public string DefaultValue;
    }
}