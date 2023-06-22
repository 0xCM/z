//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static DisasmDetail detail(DisasmSummary summary, bool pll = true)
        {
            var dst = sys.bag<DisasmDetailBlock>();
            iter(summary.LineIndex, lines => dst.Add(block(lines)), pll);
            return new DisasmDetail(summary.DataFile, resequence(dst.ToArray()));
        }
    }
}