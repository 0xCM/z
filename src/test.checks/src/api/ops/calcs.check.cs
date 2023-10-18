//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class ApiOps
{
    [CmdOp("calcs/run")]
    void RunChecks()
    {
        Run(sys.empty<string>());
    }

}