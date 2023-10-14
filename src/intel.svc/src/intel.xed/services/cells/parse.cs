//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static XedModels;
using static XedParsers;
using static sys;

partial class XedCells
{    
    public static bool parse(ReadOnlySpan<char> src, out InstCells dst)
        => inner(RuleMacros.expand(normalize(src)), out dst);

    static string normalize(ReadOnlySpan<char> body)
    {
        var buffer = text.buffer();
        var parts = text.split(text.despace(body), Chars.Space);
        for(var i=0; i<parts.Length; i++)
        {
            if(i != 0)
                buffer.Append(Chars.Space);

            ref readonly var part = ref skip(parts,i);
            if(part == "MAP5")
                buffer.Append("MAP=5");
            else if(part=="MAP6")
                buffer.Append("MAP=6");
            else 
                buffer.Append(part);
        }
        return buffer.Emit();
    }

    static bool inner(string src, out InstCells dst)
    {
        var result = Outcome.Success;
        var parts = text.trim(text.split(text.despace(src), Chars.Space));
        var count = parts.Length;
        dst = new(alloc<CellValue>(count));
        for(var i=0; i<count; i++)
        {
            ref readonly var part = ref skip(parts,i);
            result = parse(part, out dst[i]);
            if(result.Fail)
                Errors.Throw(result.Message);
        }
        return true;
    }    
    
    public static Outcome parse(string src, out CellValue dst)
    {
        dst = CellValue.Empty;
        Outcome result = (false, string.Format("Unrecognized segment '{0}'", src));
        if(IsHexLiteral(src))
        {
            result = XedParsers.parse(src, out Hex8 x);
            if(result)
                dst = x;
            else
                result = (false, AppMsg.ParseFailure.Format(nameof(Hex8), src));
        }
        else if(IsBinaryLiteral(src))
        {
            result = XedParsers.parse(src, out uint5 x);
            if(result)
                dst = x;
            else
                result = (false, AppMsg.ParseFailure.Format(nameof(uint5), src));

        }
        else if(IsSeg(src))
        {
            result = XedCellParser.parse(src, out InstFieldSeg x);
            if(result)
                dst = x;
        }
        else if(IsExpr(src))
        {
            result = XedCellParser.expr(src, out CellExpr x);
            if(result)
                dst = x;
            else
                result = (false, AppMsg.ParseFailure.Format(nameof(CellExpr), src));
        }
        else if(IsNonterm(src))
        {
            result = XedParsers.parse(src, out Nonterminal x);
            if(result)
                dst = x;
            else
                result = (false, AppMsg.ParseFailure.Format(nameof(Nonterminal), src));
        }
        else if (XedParsers.parse(src, out byte a))
        {
            result = true;
            dst = a;
        }

        return result;
    }
}