//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
    public struct InstBlockLineSpec
    {
        const string TableId = "xed.instblocks.lines";

        [Render(6)]
        public uint Seq;

        [Render(12)]
        public uint MinLine;

        [Render(12)]
        public uint MaxLine;

        [Render(12)]
        public uint MinChar;

        [Render(12)]
        public uint MaxChar;

        [Render(8)]
        public uint LineCount;

        [Render(64)]
        public XedInstForm Form;

        [Render(128)]
        public BitVector64<BlockFieldName> Fields;

        [Render(1)]
        public ReadOnlySeq<string> Lines;

        public static InstBlockLineSpec Empty => default;
    }
}
