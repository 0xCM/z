//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public enum CultRecordKind : byte
    {
        None = 0,

        Label,

        Statement,

        Summary,
    }

    public struct CultRecord
    {
        public uint LineNumber;

        public CultRecordKind RecordKind;

        public TextBlock Label;

        public TextBlock Statement;

        public TextBlock Comment;

        public static CultRecord Empty
        {
            get
            {
                var dst = new CultRecord();
                dst.LineNumber = 0;
                dst.RecordKind = 0;
                dst.Label = TextBlock.Empty;
                dst.Statement = TextBlock.Empty;
                dst.Comment = TextBlock.Empty;
                return dst;
            }
        }
    }
}