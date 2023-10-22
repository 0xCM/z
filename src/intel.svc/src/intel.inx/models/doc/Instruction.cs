//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class IntrinsicsDoc
{
    public readonly struct Instruction
    {
        public const string ElementName = "instruction";

        public readonly AsmMnemonic name;

        public readonly @string form;

        public readonly XedFormType xed;

        public Instruction(string name, string form, XedFormType xed)
        {
            this.name = name;
            this.form = form;
            this.xed  = xed;
        }

        public InstRef ToInstRef()
            => new(name, xed, form);
            
        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => name.IsNonEmpty && text.empty(form) && xed == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
            => IsEmpty ? EmptyString : string.Format("{0} {1}", name, form);

        public override string ToString()
            => Format();

        public static Instruction Empty => new (EmptyString, EmptyString, 0);
    }
}
