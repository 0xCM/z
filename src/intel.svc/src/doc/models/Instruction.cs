//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class IntrinsicsDoc
    {
        public readonly struct Instruction
        {
            public const string ElementName = "instruction";

            public readonly @string name;

            public readonly @string form;

            public readonly InstFormType xed;

            public Instruction(string name, string form, InstFormType xed)
            {
                this.name = name;
                this.form = form;
                this.xed  = xed;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => text.empty(name) && text.empty(form) && xed == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public AmsInstClass InstClass
                => AmsInstClass.parse(name, out _);

            public string Format()
                => IsEmpty ? EmptyString : string.Format("{0} {1}", name, form);

            public override string ToString()
                => Format();

            public static Instruction Empty => new Instruction(EmptyString, EmptyString, 0);
        }
    }
}