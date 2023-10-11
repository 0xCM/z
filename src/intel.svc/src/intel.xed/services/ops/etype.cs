//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static sys;
using static XedModels;

partial class Xed
{
    public static ConcurrentDictionary<AsmOpCodeClass,Index<InstGroupSeq>> CalcInstGroupLookup(Index<InstGroup> src, bool pll)
    {
        var dst = cdict<AsmOpCodeClass,Index<InstGroupSeq>>();
        iter(groupseq(src), kvp => dst.TryAdd(kvp.Key, resequence(kvp.Value)), pll);
        return dst;
    }

    static Index<InstGroupSeq> resequence(Index<InstGroupSeq> src)
    {
        var dst = src.Sort(new PatternOrder(true));
        for(var i=0u; i<dst.Count; i++)
            dst[i].Seq = i;
        return dst;
    }

    static Dictionary<AsmOpCodeClass,Index<InstGroupSeq>> groupseq(Index<InstGroup> src)
        => src.SelectMany(x => x.Members.Select(x => x.Seq)).GroupBy(x => x.OpCodeClass).Select(x => (x.Key, x.Index())).ToDictionary();
}
