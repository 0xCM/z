//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using TK = XedFormToken.TokenKind;

    partial class XedForms
    {
        public static int cmp(XedFormToken a, XedFormToken b)
        {
            var result = ((byte)a.Kind).CompareTo((byte)b.Kind);
            if(result == 0)
            {
                switch(a.Kind)
                {
                    case TK.InstClass:
                        result = ((ushort)a.InstClassValue()).CompareTo((ushort)b.InstClassValue());
                    break;
                    case TK.Hex8Lit:
                        result = a.Hex8Value().CompareTo(b.Hex8Value());
                    break;
                    case TK.Hex16Lit:
                        result = a.Hex16Value().CompareTo(b.Hex16Value());
                    break;
                    default:
                        result = a.Value.CompareTo(b.Value);
                    break;
                }
            }
            return result;
        }
    }
}