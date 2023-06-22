//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedRules
    {
        public static Index<RuleTableBlock> blocks(RuleTableKind kind)
        {
            var src = XedPaths.Service.RuleSource(kind);
            var lines = src.ReadNumberedLines();
            var offsets = list<LineNumber>();
            var names = list<string>();
            for(var i=0u; i<lines.Count; i++)
            {
                ref readonly var line = ref lines[i];
                var data = text.trim(text.despace(line.Content));
                if(text.empty(data) || text.begins(data, Chars.Hash))
                    continue;

                var j = text.index(data,Chars.Hash);
                var content = (j > 0 ? text.left(data,j) : data).Trim();
                if(text.ends(content,"()::"))
                {
                    var k = text.index(content, Chars.LParen);
                    var name = text.left(content,k);
                    names.Add(name.Remove("xed_reg_enum_t").Trim());
                    offsets.Add(line.LineNumber);
                }
            }

            var dst = alloc<RuleTableBlock>(names.Count);
            var pos = 0;
            var view = lines.View;
            for(var i=0; i<names.Count; i++)
            {
                var name = names[i];
                var i0 = offsets[i];
                ref var target = ref seek(dst,i);
                if(i < names.Count - 1)
                {
                    var i1 = offsets[i+1];
                    var seg = sys.segment(view, i0, i1 - 1);
                    var parts = list<TextLine>();
                    for(var j=0; j<seg.Length; j++)
                    {
                        ref readonly var line = ref skip(seg,j);
                        var part = text.trim(text.despace(line.Content));
                        if(text.empty(part) || text.begins(part,Chars.Hash) || text.ends(part, "::") || text.ends(part, "()") || text.begins(part, "SEQUENCE "))
                            continue;

                        var k = text.index(part,Chars.Hash);
                        if(k>0)
                            parts.Add((line.LineNumber,text.left(part,k)));
                        else
                            parts.Add((line.LineNumber,part));
                    }
                    target = new RuleTableBlock(kind, name, i0, parts.ToArray());
                }
                else
                {
                    var seg = sys.slice(view, i0);
                    var parts = list<TextLine>();
                    for(var j=0; j<seg.Length; j++)
                    {
                        ref readonly var line = ref skip(seg,j);
                        var part = text.trim(text.despace(line.Content));
                        if(text.empty(part) || text.begins(part,Chars.Hash))
                            continue;
                        parts.Add((line.LineNumber,part));
                    }
                    target = new RuleTableBlock(kind, name, i0, parts.ToArray());
                }
            }

            return dst.Sort();
        }
    }
}