//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        LlvmDataCalcs LLvmCalcs => Wf.LlvmDataCalcs();

        [CmdOp("llvm/emit/asmids")]
        void EmitAsmIds()
        {
            var src = LLvmCalcs.CalcAsmIdentifiers(LlvmTargetName.x86);
            DataEmitter.Emit(src);
        }

    }
}