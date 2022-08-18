//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LlvmAsmVariation> AsmVariations()
            => (Index<LlvmAsmVariation>)DataSets.GetOrAdd(nameof(AsmVariations), _ => DataLoader.LoadAsmVariations());
    }
}