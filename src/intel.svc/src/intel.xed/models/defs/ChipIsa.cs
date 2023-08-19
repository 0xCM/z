//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly struct ChipIsa
    {
        public readonly ChipCode Chip;

        public readonly Index<FormImport> Forms;

        [MethodImpl(Inline)]
        public ChipIsa(ChipCode kind, FormImport[] forms)
        {
            Chip = kind;
            Forms = forms;
        }
    }
}
