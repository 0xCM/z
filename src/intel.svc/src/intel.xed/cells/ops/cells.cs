//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRules;
using static sys;

using R = XedRules;

partial struct XedCells
{
    [MethodImpl(Inline)]
    public static GridCell cell(in RuleCell src)
        => new (src.Key, ColType.field(src.Field), src.Size, src.Value);

    public static Index<GridCell> cells(in CellRow src)
    {
        var count = src.CellCount;
        var dst = alloc<GridCell>(count);
        for(var i=0; i< count; i++)
            seek(dst,i) = cell(src[i]);
        return dst;
    }

    public static byte cols(in CellTable src)
        => (byte)src.Rows.Select(row => cells(row).Count).Storage.Max();

    public static bool reg(FieldKind field, string value, out FieldValue dst)
    {
        var result = false;
        dst = R.FieldValue.Empty;
        if(XedParsers.IsNonterm(value))
        {
            result = XedParsers.parse(value, out RuleName name);
            dst = new(field, name);
        }
        else if(XedParsers.parse(value, out XedRegId reg))
        {
            dst = new (field, reg);
            result = true;
        }
        else if(XedParsers.parse(value, out RuleKeyword kw))
        {
            dst = new(kw);
            result = true;
        }
        return result;
    }
}