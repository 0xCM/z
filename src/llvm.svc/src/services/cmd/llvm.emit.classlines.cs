//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/classlines")]
        void ClassLines(CmdArgs args)
            => Query.FileEmit(DataProvider.ClassLines(arg(args,0).Value), "llvm.classes.lines", arg(args,0).Value);
    }
}