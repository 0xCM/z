//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static Detail detail(XedDisasmSummary summary, bool pll = true)
        {
            var dst = sys.bag<DetailBlock>();
            iter(summary.LineIndex, lines => dst.Add(block(lines)), pll);
            return new Detail(summary.DataFile, resequence(dst.ToArray()));
        }
    }
}