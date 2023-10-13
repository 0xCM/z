//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static XedModels;
using static XedRules;
using static sys;

using N = XedZ.BlockFieldName;

partial class XedZ
{        
    public static ReadOnlySeq<InstBlockPattern> patterns()
    {
        var path =  XedPaths.DocSource(XedDocKind.RuleBlocks);
        var patterns = bag<InstBlockPattern>();
        var lines = XedZ.lines(path);
        piter(lines.AsParallel(), spec => {
            var fields = list<BlockField>();
            var result = true;
            patterns.Add(pattern(spec));
        });

        var records = patterns.OrderBy(x => x.Form).ThenBy(x => x.Body.Count).Array().Sort();
        var form = XedInstForm.Empty;
        var j=z8;
        for(var i=0u; i<records.Length; i++)
        {
            ref var record = ref seek(records,i);
            if(record.Form != form)
            {
                j=0;
                form = record.Form;
            }
            record.Seq = i;
            record.Index=j++;
        }
        return records;        
    }
}