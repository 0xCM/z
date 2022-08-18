//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/tool")]
        void Tool(CmdArgs args)
        {
            var result = Outcome.Success;
            if(args.Count == 0)
            {
                if(SelectedTool.IsNonEmpty)
                    Write(SelectedTool.Format());
                else
                    Write("No tool selected");
            }
            else
            {
                SelectedTool = arg(args,0).Value;
                Write(SelectedTool.Format());
            }
        }
    }
}
