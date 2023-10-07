//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedModels;

partial class XedDisasm
{
    public static void instruction(InstructionId id, string expr, InstFieldValues props, out Instruction dst)
        => dst = new Instruction(id, expr, props.InstClass, props.InstForm, props);

    public static void parse(in XedDisasmLines src, out Instruction dst)
        => instruction(src.Row.InstructionId, src.Block.Props.Content, fields(src.Block), out dst);

    public static uint parse(in XedDisasmBlock src, out InstFieldValues dst)
    {
        var content = text.trim(text.despace(src.Props.Content));
        var i = text.index(content,Chars.Space);
        var @class = text.left(content,i);
        var right = text.right(content,i);
        var j = text.index(right, Chars.Space);
        var form = text.left(right,i);
        var props = text.trim(text.split(text.right(right,j), Chars.Comma));
        var count = props.Length;
        var facets = alloc<Facet<string>>(count + 2);
        var k=0u;
        seek(facets,k++) = (nameof(FieldKind.ICLASS), @class);
        seek(facets,k++) = (nameof(XedInstForm), form);
        for(var m=0; m<count; m++,k++)
        {
            var prop = skip(props,m);
            if(text.contains(prop,Chars.Colon))
            {
                var kv = text.split(prop,Chars.Colon);
                Demand.eq(kv.Length,2);
                seek(facets,k) = (skip(kv,0), skip(kv,1));
            }
            else
                seek(facets,k) = (prop, "1");
        }

        XedDisasmParse.parse(src, out var _class, out var _form);
        dst = InstFieldValues.define(_class, _form, facets);

        return k;
    }

    /// <summary>
    /// Parses an operand disassembly line
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <remarks>
    /// For example:
    /// 0		REG0/W/ZU32/EXPLICIT/NT_LOOKUP_FN/ZMM_R3
    /// 3		MEM0/R/VV/EXPLICIT/IMM_CONST/1
    /// 3		BASE0/RW/SSZ/SUPPRESSED/NT_LOOKUP_FN/SRSP
    /// </remarks>
    static Outcome parse(string src, out OpSpec dst)
    {
        dst = default;
        if(text.length(src) < 3)
            return (false, RP.Empty);

        var result = Outcome.Success;
        var data = span(src);

        var idx = text.trim(text.left(src,2));
        result = NumericParser.parse(idx, out dst.Index);
        if(result.Fail)
            return (false,AppMsg.ParseFailure.Format(nameof(dst.Index), idx));

        var aspects = text.trim(text.right(src,2));
        var parts = text.split(aspects, Chars.FSlash);
        if(parts.Length != 6)
            return (false, string.Format("Unexpected number of operand aspects in {0}", aspects));

        var i=0;
        result = XedParsers.parse(skip(parts,i++), out dst.Name);
        if(result.Fail)
            return (false, AppMsg.ParseFailure.Format(nameof(dst.Name), skip(parts,i-1)));

        dst.Kind = Xed.opkind(dst.Name);

        result = DataParser.eparse(skip(parts,i++), out dst.Action);
        if(result.Fail)
            return result;

        result = DataParser.eparse(skip(parts,i++), out dst.WidthCode);
        if(result.Fail)
            return result;

        var width = XedWidths.describe(dst.WidthCode);
        dst.BitWidth = width.Width64;
        dst.ElementType = width.ElementType;
        dst.ElementWidth = width.ElementWidth;
        dst.ElementCount = width.ElementCount;
        dst.SegType = width.SegType;

        result = XedParsers.parse(skip(parts,i++), out dst.Visibility);
        if(result.Fail)
            return result;

        result = DataParser.eparse(skip(parts,i++), out dst.OpType);
        if(result.Fail)
            return result;

        var selector = text.trim(skip(parts,i++));
        XedParsers.parse(selector, out dst.Rule);
        XedParsers.parse(selector, out dst.Reg);
        return result;
    }
}
