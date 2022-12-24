//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        static Index<InstOpClass> resequence(Index<InstOpClass> src)
        {
            src.Sort();
            for(var i=0u; i<src.Length; i++)
                src[i].Seq = i;
            return src;
        }

        public static Index<XedDisasmRow> resequence(Index<XedDisasmRow> src)
        {
            var dst = src.Sort();
            var count = dst.Count;
            for(var i=0u; i<count; i++)
                dst[i].Seq = i;
            return dst;
        }

        public static Index<DetailBlock> resequence(Index<DetailBlock> src)
        {
            var dst = src.Sort();
            for(var i=0u; i<dst.Count; i++)
            {
                var row = dst[i].DetailRow;
                row.Seq = i;
                dst[i] = new DetailBlock(row, dst[i].SummaryLines, dst[i].Instruction);
            }
            return dst;
        }
    }
}