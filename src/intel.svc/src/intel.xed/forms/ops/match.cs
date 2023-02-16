//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using TK = XedFormToken.TokenKind;

    partial class XedForms
    {
        public static bool match(string src, ReadOnlySpan<XedFormToken> tokens, out XedFormToken dst)
        {
            dst = XedFormToken.Empty;
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

        public static bool match(TK kind, string src, out XedFormToken dst)
        {
            var result = false;
            dst = XedFormToken.Empty;
            switch(kind)
            {
                case TK.InstClass:
                {
                    result = XedParsers.parse(src, out XedInstClass c);
                    if(result)
                        dst = new XedFormToken(c);
                }
                break;
                default:
                break;
            }
            return result;
        }
    }
}