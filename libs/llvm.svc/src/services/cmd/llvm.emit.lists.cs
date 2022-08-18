//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/lists")]
        Outcome EmitLists(CmdArgs args)
        {
            DataEmitter.EmitLists(DataProvider.Entities());
            return true;
        }
    }
}