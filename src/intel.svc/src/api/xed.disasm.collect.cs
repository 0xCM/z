//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedDisasmCmd
{
    [CmdOp("xed/disasm/collect")]
    void CollectDisasm(CmdArgs args)
    {
        var dst = FS.archive(args[0]);
        XedDisasm.Collect(dst);
    }
}