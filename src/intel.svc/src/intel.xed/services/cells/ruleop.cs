//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;

partial class XedCells
{
    public static bool ruleop(string src, out RuleOperator dst)
    {
        if(ruleop(src, out OperatorKind k))
        {
            dst = k;
            return true;
        }
        else
        {
            dst = default;
            return false;
        }
    }

    static bool ruleop(string src, out OperatorKind dst)
    {
        if(XedParsers.IsNe(src))
        {
            dst = OperatorKind.Ne;
            return true;
        }
        else if(XedParsers.IsEq(src))
        {
            dst = OperatorKind.Eq;
            return true;
        }
        else if(XedParsers.IsImpl(src))
        {
            dst = OperatorKind.Impl;
            return true;
        }
        else
        {
            dst = 0;
            return false;
        }
    }
}