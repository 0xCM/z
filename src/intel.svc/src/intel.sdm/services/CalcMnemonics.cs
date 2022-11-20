//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class IntelSdm
    {
        public Index<AsmMnemonic> CalcMnemonics()
            => map(LoadSigs().Select(x => x.Mnemonic.Format(MnemonicCase.Lowercase)).Distinct(), x => (AsmMnemonic)x);
    }
}