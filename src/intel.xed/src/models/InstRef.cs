//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly record struct InstRef
    {
        public readonly AsmMnemonic Name;

        public readonly XedInstForm Form;

        public readonly string Sig;

        public InstRef(AsmMnemonic name, XedInstForm form, string sig)
        {
            Name = name;
            Form = form;
            Sig = sig;
        }
    }
}