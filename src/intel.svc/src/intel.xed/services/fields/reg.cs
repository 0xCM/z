//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRules;

partial class XedFields
{
    public static bool reg(FieldKind field, string value, out FieldValue dst)
    {
        var result = false;
        dst = FieldValue.Empty;
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