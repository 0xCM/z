//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct RuleDeps
        {
            public readonly FieldSet Fields;

            public readonly RuleNames Rules;

            [MethodImpl(Inline)]
            public RuleDeps(in FieldSet fields, in RuleNames fx)
            {
                Fields = fields;
                Rules = fx;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Fields.IsEmpty && Rules.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Fields.IsNonEmpty || Rules.IsNonEmpty;
            }

            public string Format()
            {
                var fieldFmt = Fields.IsNonEmpty ? Fields.Format() : EmptyString;
                var funcFmt =  Rules.IsNonEmpty ? Rules.Format() : EmptyString;
                var sep = (text.nonempty(fieldFmt) && text.nonempty(funcFmt)) ? "," : EmptyString;
                return text.embrace(string.Format("{0}{1}{2}", fieldFmt, sep, funcFmt));
            }

            public override string ToString()
                => Format();
        }
    }
}