//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedCmd
{
    [CmdOp("xed/disasm/collect")]
    void CollectDisasm(CmdArgs args)
    {
        XedDisasm.Collect(FS.archive(args[0]));
    }
}