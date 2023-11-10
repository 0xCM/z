//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;
using static XedRules;

partial class XedFields
{
    public static InstFieldValues values(XedInstClass @class, XedInstForm form, Index<Facet<string>> src)
    {
        var dst = dict<string,string>();
        for(var i=0; i<src.Count; i++)
            dst.Add(src[i].Key, src[i].Value);
        return new InstFieldValues(@class, form, dst);
    }
}