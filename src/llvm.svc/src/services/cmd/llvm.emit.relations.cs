//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/relations")]
        void EmitDefRelations()
            => Query.FileEmit("llvm.defs.relations", DataProvider.DefDependencies().View);

    }
}