//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedModels;

partial class XedOps
{
    public static Index<InstOpDetail> opdetails(Index<InstPattern> src)
    {
        var buffer = list<InstOpDetail>();
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var pattern = ref src[i];
            ref readonly var ops = ref pattern.Ops;
            var count = (byte)ops.Count;
            for(var j=0; j<count; j++)
                buffer.Add(opdetail(pattern, count, ops[j]));
        }

        return buffer.ToArray().Sort(new PatternOrder());
    }
}
