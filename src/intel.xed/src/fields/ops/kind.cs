//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

using K = XedRules.FieldKind;

partial class XedFields
{
    public static K kind(string src)
    {
        var i = text.index(src, Chars.Eq);
        var j = text.index(src, Chars.LBracket);
        var k = text.index(src, "!=");
        var result = K.INVALID;

        if(j>0)
        {
            var field = text.left(src, j);
            if(XedParsers.parse(field, out result))
                return result;
            else
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), field));
        }
        else if(k>0)
        {
            var field = text.left(src,k);
            if(XedParsers.parse(field, out result))
                return result;
            else
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), field));
        }
        else if(i > 0)
        {
            var field = text.left(src,i);
            if(XedParsers.parse(field, out result))
                return result;
            else
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), field));

        }
        if(XedParsers.parse(src, out result))
            return result;

        return result;
    }
}