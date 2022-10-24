//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public LlvmAsmOpCodeMap AsmOpCodeMap(Index<X86InstDef> src)
            => (LlvmAsmOpCodeMap)DataSets.GetOrAdd(nameof(LlvmAsmOpCodeMap), _ => DataCalcs.CalcAsmOpCodeMap(src));

        public LlvmAsmOpCodeMap AsmOpCodeMap()
            => AsmOpCodeMap(Instructions());
    }
}