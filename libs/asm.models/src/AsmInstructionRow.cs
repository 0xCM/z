//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmInstructionRow : ISequential<AsmInstructionRow>, IComparable<AsmInstructionRow>
    {
        const string TableId = "asm.instruction";

        public const byte FieldCount = 7;

        [Render(AsmColWidths.Seq)]
        public uint Seq;

        [Render(AsmColWidths.DocSeq)]
        public uint DocSeq;

        [Render(AsmColWidths.OriginId)]
        public Hex32 OriginId;

        [Render(AsmColWidths.OriginName)]
        public @string OriginName;

        [Render(32)]
        public Identifier AsmName;

        [Render(AsmColWidths.AsmExpr)]
        public AsmExpr Asm;

        [Render(1)]
        public FS.FileUri Source;

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq,OriginId);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => AsmName.IsEmpty && OriginId == 0;
        }

        public int CompareTo(AsmInstructionRow src)
        {
            var result = OriginName.CompareTo(src.OriginName);
            if(result==0)
                return DocSeq.CompareTo(src.DocSeq);
            return result;
        }


        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }

        public static AsmInstructionRow Empty => default;
    }
}