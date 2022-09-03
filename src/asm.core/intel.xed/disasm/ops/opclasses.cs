//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static MachineModes;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static Index<InstOpClass> opclasses(Index<Document> src)
        {
            var buffer = hashset<InstOpClass>();
            foreach(var (summary,detail) in src)
                buffer.AddRange(detail.Blocks.Select(x => x.DetailRow).SelectMany(x => x.Ops).Select(x => XedOps.opclass(MachineModeClass.Mode64, x.Spec)).Distinct());
            var dst = buffer.Array();
            return resequence(dst);
        }

        public static Index<InstOpClass> opclasses(Document src)
            => resequence(
                src.Detail.Blocks.Select(x => x.DetailRow)
                   .SelectMany(x => x.Ops)
                   .Select(x => XedOps.opclass(MachineModeClass.Mode64, x.Spec))
                   .Distinct());
    }
}