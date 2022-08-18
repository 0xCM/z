//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using W = AsmColWidths;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct XedDisasmRow : IComparable<XedDisasmRow>
    {
        public const string TableId = "xed.disasm.summary";

        public const byte FieldCount = 11;

        [Render(W.Seq)]
        public uint Seq;

        [Render(W.DocSeq)]
        public uint DocSeq;

        [Render(W.OriginId)]
        public Hex32 OriginId;

        [Render(W.OriginName)]
        public @string OriginName;

        [Render(W.EncodingId)]
        public EncodingId EncodingId;

        [Render(W.InstructionId)]
        public InstructionId InstructionId;

        [Render(W.IP)]
        public MemoryAddress IP;

        [Render(W.Size)]
        public byte Size;

        [Render(W.EncodedHex)]
        public AsmHexCode Encoded;

        [Render(W.AsmExpr)]
        public AsmExpr Asm;

        [Render(1)]
        public FS.FileUri Source;

        public int CompareTo(XedDisasmRow src)
        {
            var result = OriginName.CompareTo(src.OriginName);
            if(result == 0)
                result = IP.CompareTo(src.IP);
            return result;
        }

        public static XedDisasmRow Empty => default;
    }
}