//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/list")]
        void EmitList(CmdArgs args)
            => Query.FileEmit("list", DataProvider.List(arg(args,0)).Items);
    }
}