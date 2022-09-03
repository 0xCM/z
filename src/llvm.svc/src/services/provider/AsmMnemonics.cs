//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    partial class LlvmDataProvider
    {
        public Index<AsmMnemonicRow> AsmMnemonics()
            => (Index<AsmMnemonicRow>)DataSets.GetOrAdd(nameof(AsmMnemonics), _ => DataCalcs.CalcAsmMnemonics(AsmVariations()));
    }
}