//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using W = AsmColWidths;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmSyntaxRow : IComparable<AsmSyntaxRow>
    {
        public const string TableId = "asm.syntax";

        public const byte FieldCount = 8;

        [Render(W.Seq)]
        public uint Seq;

        [Render(W.DocSeq)]
        public uint DocSeq;

        [Render(W.OriginId)]
        public Hex32 OriginId;

        [Render(W.OriginName)]
        public @string OriginName;

        [Render(W.AsmExpr)]
        public AsmExpr Asm;

        [Render(W.AsmSyntax)]
        public @string Syntax;

        [Render(W.EncodedHex)]
        public AsmHexCode Encoded;

        [Render(1)]
        public FS.FileUri Source;

        public AsmRowKey Key
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq,OriginId);
        }

        public int CompareTo(AsmSyntaxRow src)
        {
            var result = Source.Path.FileName.CompareTo(src.Source.Path.FileName);
            if(result==0)
                return DocSeq.CompareTo(src.DocSeq);
            return result;
        }

        public static AsmSyntaxRow Empty => default;
    }
}