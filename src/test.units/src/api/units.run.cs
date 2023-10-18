//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class ApiOps
{
    [CmdOp("units/run")]
    void RunUnits(CmdArgs args)
    {
        TestRunner.Run(sys.array(PartId.Lib, PartId.TestUnits));
    }
}