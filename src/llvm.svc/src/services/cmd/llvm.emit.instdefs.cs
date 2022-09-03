//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/instdefs")]
        void EmitInst()
            => DataEmitter.Emit(DataProvider.InstDefs());
    }
}