//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct ObjSymRow
    {
        const string TableId = "objsyms";

        public const byte FieldCount = 8;

        [Render(AsmColWidths.Seq)]
        public uint Seq;

        [Render(AsmColWidths.DocSeq)]
        public uint DocSeq;

        [Render(AsmColWidths.OriginId)]
        public Hex32 OriginId;

        [Render(10)]
        public Hex32 Offset;

        [Render(6)]
        public ObjSymCode Code;

        [Render(AsmColWidths.SymbolName)]
        public ObjSymKind Kind;

        [Render(80)]
        public string Name;

        [Render(1)]
        public FS.FileUri Source;

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq,OriginId);
        }
    }
}