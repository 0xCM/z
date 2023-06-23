//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedDisasm
    {
        public static XedDisasmDetail detail(XedDisasmSummary summary, bool pll = true)
        {
            var dst = sys.bag<XedDisasmDetailBlock>();
            iter(summary.LineIndex, lines => dst.Add(block(lines)), pll);
            return new XedDisasmDetail(summary.DataFile, resequence(dst.ToArray()));
        }
    }
}