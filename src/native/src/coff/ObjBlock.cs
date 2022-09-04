//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct ObjBlock
    {
        public const string TableId = "obj.blocks";

        public const byte FieldCount = 7;

        [Render(AsmColWidths.Seq)]
        public uint Seq;

        [Render(AsmColWidths.BlockNumber)]
        public uint BlockNumber;

        [Render(AsmColWidths.OriginId)]
        public Hex32 OriginId;

        [Render(AsmColWidths.BlockName)]
        public Identifier BlockName;

        [Render(AsmColWidths.BlockAddress)]
        public MemoryAddress BlockAddress;

        [Render(AsmColWidths.BlockSize)]
        public ByteSize BlockSize;

        [Render(1)]
        public _FileUri Source;

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq, BlockNumber,OriginId);
        }
    }
}