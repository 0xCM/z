//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly partial struct CellParser
        {
            public static Outcome parse(string src, out InstFieldSeg dst)
            {
                var result = Outcome.Success;
                dst = InstFieldSeg.Empty;
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                result = i>0 && j>i;
                if(result)
                {
                    result = XedParsers.parse(text.left(src,i), out FieldKind field);
                    if(!result)
                        return false;

                    result = XedParsers.segdata(src, out var data);
                    if(!result)
                        return result;

                    var literal = XedParsers.IsBinaryLiteral(data);
                    if(!literal)
                    {
                        var type = InstSegTypes.type(data);
                        if(type.IsNonEmpty)
                        {
                            dst = new (field, type);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        result = XedParsers.bitnumber(data, out byte n, out byte value);
                        if(result)
                            dst = new (field, BitNumber.generic(n, value));
                    }
                }

                return result;
            }
        }
    }
}