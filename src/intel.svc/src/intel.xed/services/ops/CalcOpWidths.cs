//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;

partial class Xed
{
    public static Index<OpWidthDetail> CalcOpWidths()
    {
        var buffer = dict<WidthCode,OpWidthDetail>();
        var symbols = Symbols.index<WidthCode>();
        var src = XedDb.DocSource(XedDocKind.Widths);
        using var reader = src.Utf8LineReader();
        var result = Outcome.Success;
        while(reader.Next(out var line))
        {
            var content = text.trim(line.Content);
            if(text.empty(content) || content.StartsWith(Chars.Hash))
                continue;

            var i = text.index(content, Chars.Hash);
            if(i>0)
                content = text.left(content,i);

            var cells = text.split(text.despace(content), Chars.Space);
            if(cells.Length < 3)
            {
                result = (false, content);
                break;
            }

            ref readonly var code = ref skip(cells,0);
            ref readonly var xtype = ref skip(cells,1);
            ref readonly var wdefault = ref skip(cells,2);

            var dst = OpWidthDetail.Empty;
            result = XedParsers.parse(code, out dst.Code);

            if(result.Fail)
            {
                result = (false, Msg.ParseFailure.Format(nameof(dst.Code), code));
                break;
            }

            if(dst.Code == 0)
                continue;

            symbols.MapKind(dst.Code, out var sym);
            dst.Name = sym.Expr.Format();
            result = XedParsers.parse(xtype, out dst.ElementType);
            if(result.Fail)
            {
                result = (false,Msg.ParseFailure.Format(nameof(dst.ElementType), xtype));
                break;
            }

            dst.ElementWidth = XedOps.width(dst.Code, dst.ElementType);

            result = ParseWidthValue(wdefault, out dst.Width16);
            if(result.Fail)
            {
                result = (false,Msg.ParseFailure.Format(nameof(dst.Width16), wdefault));
                break;
            }
            else
            {
                dst.Width32 = dst.Width16;
                dst.Width64 = dst.Width16;
            }

            if(cells.Length >= 4)
                result = ParseWidthValue(skip(cells,3), out dst.Width32);

            if(result.Fail)
            {
                result = (false,Msg.ParseFailure.Format(nameof(dst.Width32), skip(cells,3)));
                break;
            }

            if(cells.Length >= 5)
                result = ParseWidthValue(skip(cells,4), out dst.Width64);

            if(result.Fail)
            {
                result = (false,Msg.ParseFailure.Format(nameof(dst.Width64), skip(cells,4)));
                break;
            }

            dst.SegType = BitSegType.define(Xed.nclass(dst.Code), dst.Width64, dst.ElementWidth);
            buffer.TryAdd(dst.Code, dst);
        }

        // if(result.Fail)
        //     Errors.Throw(result.Message);

        return buffer.Values.Array().Sort();
    }

    static bool ParseWidthValue(string src, out ushort bits)
    {
        var result = true;
        bits = 0;
        var i = text.index(src, "bits");
        if(i > 0)
            result = DataParser.parse(text.left(src,i), out bits);
        else
        {
            result = DataParser.parse(src, out ushort bytes);
            if(result)
                bits = (ushort)(bytes*8);
        }
        return result;
    }
}