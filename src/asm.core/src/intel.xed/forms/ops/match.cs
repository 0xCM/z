//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    using TK = XedForms.FormTokenKind;

    partial class XedForms
    {
        public static bool match(string src, ReadOnlySpan<FormToken> tokens, out FormToken dst)
        {
            dst = FormToken.Empty;
            for(var i=0; i<tokens.Length; i++)
            {
                ref readonly var token = ref skip(tokens,i);
                if(token.Value == src)
                {
                    dst = token;
                    break;
                }
            }

            return dst.IsNonEmpty;
        }

        public static bool match(FormTokenKind kind, string src, out FormToken dst)
        {
            var result = false;
            dst = FormToken.Empty;
            switch(kind)
            {
                case TK.InstClass:
                {
                    result = XedParsers.parse(src, out AmsInstClass c);
                    if(result)
                        dst = new FormToken(c);
                }
                break;
                default:
                break;
            }
            return result;
        }
    }
}