//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(RecordId), StructLayout(StructLayout, Pack=1)]
    public record struct ApiTableField
    {
        const string RecordId = "api.tables";

        [Render(8)]
        public uint Seq;

        [Render(8)]
        public ushort Col;

        [Render(32)]
        public asci32 TableId;

        [Render(24)]
        public asci32 TableType;

        [Render(12)]
        public ushort FieldSize;

        [Render(12)]
        public uint TableSize;

        [Render(12)]
        public ushort RenderWidth;

        [Render(24)]
        public asci32 FieldName;

        [Render(1)]
        public asci32 FieldType;
    }
}