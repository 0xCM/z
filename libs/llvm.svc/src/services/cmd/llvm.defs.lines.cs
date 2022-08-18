//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/defs/lines")]
        Outcome Def(CmdArgs args)
        {
            Query.FileEmit(DataProvider.DefLines(arg(args,0).Value), "llvm.defs.lines", arg(args,0).Value);
            return true;
        }
    }
}