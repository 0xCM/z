//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/mnemonics")]
        void EmitMnemonics()
            => DataEmitter.Emit(DataProvider.AsmMnemonics());
    }
}