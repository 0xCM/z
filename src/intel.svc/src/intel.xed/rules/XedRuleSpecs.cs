//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedOps;
using static XedModels;
using static XedRules;

using CK = XedRules.RuleCellKind;

public readonly struct XedRuleSpecs
{
    [MethodImpl(Inline)]
    static CellInfo cellinfo(in CellTypeInfo type, LogicClass logic, string data)
        => new CellInfo(type, logic, data);

    [MethodImpl(Inline)]
    static CellInfo cellinfo(RuleOperator op)
        => new CellInfo(op);

    public static Index<TableCriteria> criteria(RuleTableKind kind)
        => criteria(XedPaths.Service.RuleSource(kind));

    public static Index<TableCriteria> criteria(FilePath src)
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
                        XedParsers.parse(name, out RuleName rn);
                        dst.Add(new (new (tkind,rn), statements.ToArray()));
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

    public static Index<TableCriteria> merge(Index<TableCriteria> src)
    {
        var dst = dict<RuleSig,TableCriteria>(src.Count);
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

    public static bool criteria(string src, out RowCriteria dst)
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

    static Index<CellInfo> cells(string src)
    {
        var input = text.trim(text.despace(src));
        var cells = list<string>();
        if(text.contains(input, Chars.Space))
        {
            var parts = text.split(input, Chars.Space);
            var count = parts.Length;
            for(var j=0; j<count; j++)
            {
                ref readonly var part = ref skip(parts,j);
                if(RuleMacros.match(part, out var match))
                {
                    var expanded = text.trim(match.Expansion);
                    if(text.contains(expanded, Chars.Space))
                    {
                        var expansions = text.split(expanded, Chars.Space);
                        for(var k=0; k<expansions.Length; k++)
                            cells.Add(skip(expansions, k));
                    }
                    else
                        cells.Add(expanded);
                }
                else
                    cells.Add(part);
            }
        }
        else
        {
            if(RuleMacros.match(input, out var match))
                cells.Add(match.Expansion);
            else
                cells.Add(input);
        }

        return cells.Map(cellinfo);
    }

    public static bool parse(string data, out CellTypeInfo dst)
    {
        Require.nonempty(data);
        Require.invariant(data.Length < 48);
        var kind = FieldParser.kind(data);
        var field = kind != 0 ? XedFields.field(kind) : FieldDef.Empty;
        ruleop(data, out RuleOperator op);
        dst = new (kind, celltype(field.Field, data), op, field.DataType, field.Size);
        return true;
    }

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

    public static bool ruleop(string src, out OperatorKind dst)
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

    static CellInfo cellinfo(string src)
    {
        parse(src, out CellTypeInfo t);
        return XedRuleSpecs.cellinfo(t, LogicKind.None, src);
    }

    public static string normalize(string src)
    {
        var dst = EmptyString;
        var i = text.index(src, Chars.Hash);
        if(i>0)
            dst = text.despace(text.trim(text.left(src, i)));
        else
            dst = text.despace(text.trim(src));

        return dst.Replace("->", "=>").Replace("|", "=>").Remove("XED_RESET");
    }

    public static TableSpecs tables(Index<TableCriteria> src)
    {
        var dst = dict<RuleSig,TableSpec>();
        var specs = alloc<TableSpec>(src.Count);
        var seq = z16;
        for(var i=z16; i<src.Count; i++)
        {
            ref readonly var table = ref src[i];
            var tix = i;
            var tk = table.TableKind;
            ref readonly var sig = ref table.Sig;
            var rows = alloc<RowSpec>(table.RowCount);
            for(ushort j=0; j<table.RowCount; j++)
            {
                var rix = j;
                ref readonly var row = ref table[j];
                var left = row.Antecedant.Select(x => cellinfo(x.TypeInfo, LogicKind.Antecedant, x.Data));
                var right = row.Consequent.Select(x => cellinfo(x.TypeInfo, LogicKind.Consequent, x.Data));
                var count = left.Count + 1 + right.Count;
                var keys = alloc<CellKey>(count);
                var cells = alloc<CellInfo>(count);
                var m=z8;
                var kw = RuleKeyword.Empty;
                for(var k=0; k<left.Count; k++,m++)
                {
                    ref readonly var ci = ref left[k];
                    if(ci.IsKeyword)
                        XedParsers.parse(ci.Data, out kw);
                    seek(keys,m) = new CellKey(seq++, tix, rix, m, LogicKind.Antecedant, left[k].Kind, tk, sig.TableName, left[k].Field, kw.KeywordKind);
                    seek(cells, m) = ci;
                }

                {
                    seek(keys,m) = new CellKey(seq++, tix, rix, m, LogicKind.Operator, RuleCellKind.Operator, tk, sig.TableName, FieldKind.INVALID, KeywordKind.None);
                    seek(cells, m) = cellinfo(OperatorKind.Impl);
                    m++;
                }

                for(var k=0; k<right.Count; k++,m++)
                {
                    ref readonly var ci = ref right[k];
                    if(ci.IsKeyword)
                        XedParsers.parse(ci.Data, out kw);
                    seek(keys,m) = new CellKey(seq++, tix, rix, m, LogicKind.Consequent, right[k].Kind, tk, sig.TableName, right[k].Field, kw.KeywordKind);
                    seek(cells, m) = ci;
                }
                seek(rows,j) = new RowSpec(sig, tix, rix, keys, cells);
            }

            var spec = new TableSpec(tix, sig, rows);
            seek(specs,i) = spec;
            dst.Add(sig, spec);
        }
        return specs.Select(x => (x.Sig,x)).ToDictionary();
    }

    static RuleCellType celltype(FieldKind field, string data)
    {
        var result = false;
        var input = XedRuleSpecs.normalize(data);
        var dst = RuleCellType.Empty;
        var isNonTerm = text.contains(input, "()");
        if(XedParsers.IsExpr(input))
        {
            result = ruleop(input, out RuleOperator op);
            if(!result)
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleOperator), input));

            switch(op.Kind)
            {
                case OperatorKind.Eq:
                    if(isNonTerm)
                        dst = CK.NtExpr;
                    else
                        dst = CK.EqExpr;
                break;
                case OperatorKind.Ne:
                    dst = CK.NeqExpr;
                break;
                case OperatorKind.And:
                case OperatorKind.Impl:
                    dst = CK.Operator;
                break;
            }
        }
        else
        {
            if(isNonTerm)
                dst = CK.NtCall;
            else if(XedParsers.IsInt(data))
                dst = CK.IntVal;
            else if(XedParsers.IsHexLiteral(data))
                dst = CK.HexLit;
            else if(XedParsers.IsBinaryLiteral(data))
                dst = CK.BitLit;
            else if(XedParsers.IsImpl(input))
                dst = CK.Operator;
            else if(XedParsers.parse(input, out WidthVar wv))
                dst = CK.WidthVar;
            else if(XedParsers.IsSeg(input))
            {
                if(field != 0)
                {
                    if(WidthVar.test(input))
                        dst = CK.WidthVar;
                    else
                        dst = CK.InstSeg;
                }
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCellType), input));
            }
            else if(XedParsers.parse(input, out RuleKeyword keyword))
                dst = CK.Keyword;
            else
                dst = CK.SegVar;
        }

        Require.invariant(dst.IsNonEmpty);
        return dst;
    }
}

