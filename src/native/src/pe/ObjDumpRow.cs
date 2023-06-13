//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = AsmColWidths;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public record struct ObjDumpRow : IComparable<ObjDumpRow>, ISequential<ObjDumpRow>
    {
        const string TableId = "llvm.objdump";

        public const string BlockStartMarker = "<blockstart>";

        [Render(W.Seq)]
        public uint Seq;

        [Render(W.DocSeq)]
        public uint DocSeq;

        [Render(W.OriginId)]
        public Hex32 OriginId;

        [Render(W.EncodingId)]
        public EncodingId EncodingId;

        [Render(W.InstructionId)]
        public InstructionId InstructionId;

        [Render(W.SectionName)]
        public TextBlock Section;

        [Render(W.BlockAddress)]
        public MemoryAddress BlockAddress;

        [Render(W.BlockName)]
        public TextBlock BlockName;

        [Render(W.IP)]
        public Address32 IP;

        [Render(W.Size)]
        public byte Size;

        [Render(W.EncodedHex)]
        public AsmHexCode Encoded;

        [Render(W.AsmExpr)]
        public AsmExpr Asm;

        [Render(W.SyntaxComment)]
        public AsmInlineComment Comment;

        [Render(1)]
        public FilePath Source;

        public string DocName
            => Source.FileName.Format();

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq,OriginId);
        }

        public static ObjDumpRow Empty()
        {
            var dst = new ObjDumpRow();
            dst.Section = TextBlock.Empty;
            dst.BlockAddress = 0u;
            dst.BlockName = TextBlock.Empty;
            dst.IP = 0;
            dst.Encoded = BinaryCode.Empty;
            dst.Asm = EmptyString;
            dst.Source = FilePath.Empty;
            dst.Comment = AsmInlineComment.Empty;
            return dst;
        }

        public int CompareTo(ObjDumpRow src)
        {
            var result = DocName.CompareTo(src.DocName);
            if(result==0)
                result = IP.CompareTo(src.IP);
            return result;
        }

        public static ObjDumpRow Init(FilePath path)
        {
            var dst = Empty();
            dst.OriginId = (Hex32)path.Hash;
            return dst;
        }

        public bool IsBlockStart
        {
            [MethodImpl(Inline)]
            get => text.contains(Asm.Format(), BlockStartMarker);
        }

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }
    }
}