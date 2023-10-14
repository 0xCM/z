//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static XedModels;
using static sys;

using N = XedZ.BlockFieldName;

partial class XedZ
{        
    public static IEnumerable<InstBlockLineSpec> lines()
        => lines(XedPaths.RuleBlockSource());

    public static IEnumerable<InstBlockLineSpec> lines(FilePath path)
    {
        using var src = MemoryFiles.map(path);
        var _dst = list<InstBlockLineSpec>();
        lines(Lines.lines(src), _dst);   
        return _dst;     
    }

    static void lines(ReadOnlySpan<string> src, List<InstBlockLineSpec> dst)
    {
        const string FirstItemMarker = "amd_3dnow_opcode:";
        const string LastItemMarker = "EOSZ_LIST:";
        const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
        const string IFormMarker = "iform:";
        var fields = InstBlockLineSpec.Empty;
        var buffer = list<LineInterval<InstBlockLineSpec>>();
        var form = XedInstForm.Empty;
        var name = EmptyString;
        var value = EmptyString;
        var field = N.amd_3dnow_opcode;
        var counter = 0u;
        var min = 0u;
        var seq = 0u;

        for(var i=0u; i<src.Length; i++)
        {
            var line = text.trim(skip(src,i));
            counter += (uint)line.Length;
            if(split(line, out name, out value))
            {
                if(parse(name, out field))
                    fields.Fields[field] = bit.On;
            }
            
            if(text.begins(line,FirstItemMarker))
                fields.MinLine = i;
            else if(text.begins(line, LastItemMarker))
            {
                fields.MaxLine = i;
                fields.MinChar = min;
                fields.MaxChar = counter;
                fields.Seq = seq++;
                fields.LineCount = fields.MaxLine - fields.MinLine + 1;
                fields.Lines = slice(src,fields.MinLine, fields.LineCount).ToArray();
                dst.Add(fields);
                fields = InstBlockLineSpec.Empty;
                min = counter+1;
            }
            else
            {
                var j = text.index(line,IFormMarker);
                if(j >= 0)
                    XedParsers.parse(value, out fields.Form);
            }
        }
    }
}