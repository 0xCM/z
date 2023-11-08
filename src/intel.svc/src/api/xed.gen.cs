//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedCmd
{
    [CmdOp("xed/gen")]
    void Gen()
    {
        var context = XedMachines.context();
        var dst = text.emitter();
        XedMachines.gen(context,dst);
        Channel.FileEmit(dst.Emit(), FS.path("D:/env/dev/z0/src/intel.svc/src/intel.xed/gen/XedMachine.cs"));
    }

    void GenFieldBits()
    {
        var fields = XedTables.FieldsReflected();

    }
}