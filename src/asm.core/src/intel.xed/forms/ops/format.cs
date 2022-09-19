//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using TK = XedForms.FormTokenKind;

    partial class XedForms
    {
        public static string format(FormToken src)
        {
            var dst = EmptyString;
            switch(src.Kind)
            {
                case TK.InstClass:
                    dst = src.InstClassValue().Format();
                break;
                case TK.Hex8Lit:
                    dst = src.Hex8Value().Format();
                break;
                case TK.Hex16Lit:
                    dst = src.Hex16Value().Format();
                break;
                default:
                    dst = src.Value.Format();
                break;
            }
            return dst;
        }
    }
}