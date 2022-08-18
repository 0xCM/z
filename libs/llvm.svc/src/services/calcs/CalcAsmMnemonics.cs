//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    using Asm;

    partial class LlvmDataCalcs
    {
        public Index<AsmMnemonicRow> CalcAsmMnemonics(Index<LlvmAsmVariation> src)
        {
            return  data(nameof(AsmMnemonicRow), Calc);
            Index<AsmMnemonicRow> Calc()
            {
                var mnemonics = src.Where(x => x.Mnemonic.IsNonEmpty).Map(x => x.Mnemonic).Distinct().Sort();
                var count = (ushort)mnemonics.Count;
                var dst = alloc<AsmMnemonicRow>(count);
                for(var i=z16; i<count; i++)
                {
                    ref readonly var m = ref mnemonics[i];
                    seek(dst,i) = new AsmMnemonicRow(i, m);
                }
                return dst;
            }
        }
    }
}