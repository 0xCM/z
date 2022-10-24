//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataCalcs
    {
        public Index<X86InstDef> CalcInstructions(Index<LlvmEntity> src)
            => Data(nameof(X86InstDef), () => src.Where(e => e.IsInstruction()).Select(e => e.ToInstruction()));
    }
}