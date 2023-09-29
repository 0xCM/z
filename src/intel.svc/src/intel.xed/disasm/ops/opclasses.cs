//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;
    using static XedModels;
    using static MachineModes;

    partial class XedDisasm
    {
        public static Index<InstOpClass> opclasses(ParallelQuery<XedDisasmDoc> src)
        {
            var buffer = hashset<InstOpClass>();
            foreach(var (summary,detail) in src)
                buffer.AddRange(detail.Blocks.Select(x => x.DetailRow).SelectMany(x => x.Ops).Select(x => Xed.opclass(MachineModeClass.Mode64, x.Spec)).Distinct());
            var dst = buffer.Array();
            return resequence(dst);
        }

        public static Index<InstOpClass> opclasses(XedDisasmDoc src)
            => resequence(
                src.Detail.Blocks.Select(x => x.DetailRow)
                   .SelectMany(x => x.Ops)
                   .Select(x => Xed.opclass(MachineModeClass.Mode64, x.Spec))
                   .Distinct());
    }
}