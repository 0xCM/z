//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string DefLineageQuery = "llvm/defs/lineage";

        [CmdOp(DefLineageQuery)]
        Outcome QueryDefLineage(CmdArgs args)
        {
            Query.FileEmit(DefLineageQuery, DataProvider.DefLineage().Values);
            return true;
        }
    }
}