//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using W = AsmColWidths;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct AsmCodeRow : IComparable<AsmCodeRow>
    {
        public const string TableId = "asm.code";

        public const byte FieldCount = 12;

        [Render(W.Seq)]
        public uint Seq;

        [Render(W.DocSeq)]
        public uint DocSeq;

        [Render(W.OriginId)]
        public Hex32 OriginId;

        [Render(W.OriginName)]
        public Label OriginName;

        [Render(W.EncodingId)]
        public EncodingId EncodingId;

        [Render(W.InstructionId)]
        public InstructionId InstructionId;

        [Render(W.IP)]
        public MemoryAddress IP;

        [Render(W.Size)]
        public byte Size;

        [Render(W.EncodedHex)]
        public HexRef Encoded;

        [Render(W.AsmExpr)]
        public SourceText Asm;

        [Render(W.BlockName)]
        public Label BlockName;

        [Render(1)]
        public MemoryAddress BlockBase;

        public int CompareTo(AsmCodeRow src)
        {
            var result = OriginName.CompareTo(src.OriginName);
            if(result == 0)
                result = IP.CompareTo(src.IP);
            return result;
        }
    }
}