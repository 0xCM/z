//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedDisasmCmd
{
    [CmdOp("xed/disasm/collect")]
    void CollectDisasm(CmdArgs args)
    {
        var src = FS.archive(args[0]);
        var project = new DevProject(src.Root);
        XedDisasm.Collect(project);
    }
}