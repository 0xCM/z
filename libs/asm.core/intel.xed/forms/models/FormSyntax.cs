//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedForms
    {
        public readonly struct FormSyntax
        {
            readonly Index<FormToken> Tokens;

            [MethodImpl(Inline)]
            public FormSyntax(FormToken[] src)
            {
                Tokens = src;
            }

            public static FormSyntax Empty => new FormSyntax(sys.empty<FormToken>());
        }
    }
}