//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;
using static XedRules;

partial class XedCells
{
    public static Seq<TableCriteria> criteria(RuleTableKind kind, Action<object> status = null)
        => criteria(XedPaths.InstPatternSource(kind), status);

    public static Seq<TableCriteria> criteria(FilePath src, Action<object> status = null)
    {
        var skip = hashset("XED_RESET");
        using var reader = src.Utf8LineReader();
        var counter = 0u;
        var dst = list<TableCriteria>();
        var tkind = XedPaths.tablekind(src.FileName);
        var statements =list<RowCriteria>();
        var name = EmptyString;
        while(reader.Next(out var line))
        {
            status?.Invoke(line);
            
            if(CellParser.RuleForm(line.Content) == RuleFormKind.SeqDecl)
            {
                while(reader.Next(out line))
                    if(line.IsEmpty)
                        break;
                continue;
            }

            var content = text.trim(text.despace(line.Content));
            if(text.empty(content) || text.begins(content, Chars.Hash))
                continue;

            var k = text.index(content,Chars.Hash);
            if(k > 0)
                content = text.trim(text.left(content,k));

            if(text.ends(content, "()::"))
            {
                if(counter != 0)
                {
                    if(!skip.Contains(name))
                    {
                        if(XedParsers.parse(name, out RuleName rn))
                            dst.Add(new (new (tkind,rn), statements.ToArray()));
                        else
                            sys.@throw($"UnknownRule:'{name}'");
                    }

                    statements.Clear();
                }

                name = text.remove(content,"()::");
                var i = text.index(name, Chars.Space);
                if(i > 0)
                    name = text.right(name,i);
                counter++;
            }
            else
            {
                if(criteria(content, out RowCriteria s))
                    statements.Add(s);
            }
        }

        return merge(dst.ToArray());
    }

    static Seq<TableCriteria> merge(ReadOnlySeq<TableCriteria> src)
    {
        var dst = dict<RuleIdentity,TableCriteria>(src.Count);
        for(var i=0u; i<src.Count; i++)
        {
            ref readonly var table = ref src[i];
            if(table.SigKey.IsEmpty)
                continue;

            if(dst.TryGetValue(table.SigKey, out var t))
                dst[table.SigKey] = t.Merge(table);
            else
            {
                if(!dst.TryAdd(table.SigKey,table))
                    Errors.Throw(string.Format("Duplicate sig {0}", table.SigKey));
            }
        }

        var specs = dst.Values.Array().Sort();
        for(var i=0u; i<specs.Length; i++)
            seek(specs,i)= seek(specs,i).WithId(i);
        return specs;
    }

    static bool criteria(string src, out RowCriteria dst)
    {
        var input = normalize(src);
        var i = text.index(input,"=>");
        dst = RowCriteria.Empty;
        if(i > 0)
        {
            var left = text.trim(text.left(input, i));
            var premise = text.nonempty(left) ? cells(left) : Index<CellInfo>.Empty;
            var right = text.trim(text.right(input, i+1));
            var consequent = text.nonempty(right) ? cells(right) : Index<CellInfo>.Empty;
            if(premise.Count != 0 || consequent.Count != 0)
                dst = new RowCriteria(premise, consequent);
        }
        else
            Errors.Throw(AppMsg.ParseFailure.Format(nameof(RowCriteria), src));

        return dst.IsNonEmpty;
    }
}