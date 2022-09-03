//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LlvmAsmOpCode> AsmOpCodes(AsmIdentifiers asmids, LlvmAsmOpCodeMap map)
            => (Index<LlvmAsmOpCode>)DataSets.GetOrAdd(nameof(LlvmAsmOpCode), _ => DataCalcs.CalcAsmOpCodes(asmids, map));

        public Index<LlvmAsmOpCode> AsmOpCodes()
            => AsmOpCodes(AsmIdentifiers(),  AsmOpCodeMap());
    }
}