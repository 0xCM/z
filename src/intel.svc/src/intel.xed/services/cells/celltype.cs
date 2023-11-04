//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;

using CK = XedRules.RuleCellKind;

partial class XedCells
{
    [MethodImpl(Inline)]
    static CellInfo cellinfo(in CellTypeInfo type, LogicClass logic, string data)
        => new (type, logic, data);

    [MethodImpl(Inline)]
    static CellInfo cellinfo(RuleOperator op)
        => new (op);

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

    static bool parse(string data, out CellTypeInfo dst)
    {
        Require.nonempty(data);
        Require.invariant(data.Length < 48);
        var kind = XedFields.kind(data);
        var field = kind != 0 ? FieldDefs.field(kind) : FieldDef.Empty;
        ruleop(data, out RuleOperator op);
        dst = new (kind, celltype(field.Field, data), op, field.DataType, field.Size);
        return true;
    }

    static CellInfo cellinfo(string src)
    {
        parse(src, out CellTypeInfo t);
        return cellinfo(t, LogicKind.None, src);
    }

    static string normalize(string src)
    {
        var dst = EmptyString;
        var i = text.index(src, Chars.Hash);
        if(i>0)
            dst = text.despace(text.trim(text.left(src, i)));
        else
            dst = text.despace(text.trim(src));

        return dst.Replace("->", "=>").Replace("|", "=>").Remove("XED_RESET");
    }

    static RuleCellType celltype(FieldKind field, string data)
    {
        var result = false;
        var input = normalize(data);
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
