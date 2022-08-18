//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataCalcs
    {
        public Index<InstEntity> CalcInstructions(Index<LlvmEntity> src)
            => Data(nameof(InstEntity), () => src.Where(e => e.IsInstruction()).Select(e => e.ToInstruction()));
    }
}