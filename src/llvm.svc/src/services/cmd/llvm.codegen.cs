//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/codegen")]
        Outcome GenCode(CmdArgs args)
        {
            if(args.Count == 0)
                CodeGen.Run(true);
            else
            {
                arg(args,0, out bit staged);
                CodeGen.Run(staged);
            }
            return true;
        }
    }
}