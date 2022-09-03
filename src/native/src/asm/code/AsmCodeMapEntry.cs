//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = AsmColWidths;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct AsmCodeMapEntry : IComparable<AsmCodeMapEntry>
    {
        const string TableId = "asm.codemap";

        [Render(W.Seq)]
        public uint Seq;

        [Render(W.DocSeq)]
        public uint DocSeq;

        [Render(W.EncodingId)]
        public EncodingId EncodingId;

        [Render(W.OriginId)]
        public Hex32 OriginId;

        [Render(W.OriginName)]
        public Label OriginName;

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

        [Render(W.BlockNumber)]
        public uint BlockNumber;

        [Render(W.BlockAddress)]
        public MemoryAddress BlockAddress;

        [Render(W.BlockSize)]
        public ByteSize BlockSize;

        public int CompareTo(AsmCodeMapEntry src)
        {
            var result = OriginName.CompareTo(src.OriginName);
            if(result == 0)
                result = IP.CompareTo(src.IP);
            return result;
        }
    }
}