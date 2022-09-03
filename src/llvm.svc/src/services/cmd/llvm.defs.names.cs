//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/defs/names")]
        Outcome DefNames(CmdArgs args)
        {
            Query.FileEmit("llvm/defs/names", DataProvider.DefNames().View);
            return true;
        }
    }
}
