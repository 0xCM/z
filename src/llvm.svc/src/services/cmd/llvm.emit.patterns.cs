//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/patterns")]
        void EmitInstPatterns()
            => DataEmitter.Emit(DataProvider.InstPatterns());
    }
}