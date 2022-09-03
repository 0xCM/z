//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/help")]
        Outcome EmitHelp(CmdArgs args)
        {
            //Toolset.EmitHelp();
            return true;
        }
    }
}
