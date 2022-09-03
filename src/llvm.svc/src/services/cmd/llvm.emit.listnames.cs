//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/listnames")]
        void EmitListNames()
            => Query.FileEmit("llvm.lists.names", DataProvider.Lists().Map(x => x.ToNameList()).View);
    }
}