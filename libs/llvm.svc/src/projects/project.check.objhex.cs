//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("project/check/objhex")]
        Outcome CheckObjHex(CmdArgs args)
            => Coff.CheckObjHex(Context());
    }
}