//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;
using static XedModels.EASZ;
using static XedModels.EOSZ;
using static MachineModes;
using static MachineModes.MachineModeClass;
using static XedModels.DispWidth;

using EK = XedModels.ElementKind;
using WC = XedModels.WidthCode;

using static sys;

public class XedWidths
{
    public static XedWidths FromSource()
        => FromSource(XedPaths.DocSource(XedDocKind.Widths));

    public static XedWidths FromSource(FilePath src)
    {
        var buffer = dict<WidthCode,OpWidthDetail>();
        var symbols = Symbols.index<WidthCode>();
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

            dst.ElementWidth = XedWidths.width(dst.Code, dst.ElementType);

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

        if(!result)
            sys.@throw(result.Message);
            
        return new(buffer);
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

    [MethodImpl(Inline)]
    public static OpWidthDetail describe(WidthCode code)
    {
        var dst = OpWidthDetail.Empty;
        XedImport.detail(code, out dst);
        return dst;
    }

    public static OpWidth width(MachineMode mode, WidthCode code)
    {
        var dst = OpWidth.Empty;
        if(code == 0)
            return dst;
        else if(XedImport.detail(code, out var info))
        {
            switch(mode.Class)
            {
                case MachineModeClass.Mode16:
                    dst = new OpWidth(code, info.Width16);
                break;
                case MachineModeClass.Not64:
                case MachineModeClass.Mode32:
                    dst = new OpWidth(code, info.Width32);
                break;

                default:
                    dst = new OpWidth(code, info.Width64);
                break;
            }
        }
        else
            Errors.Throw(code.ToString());
        return dst;
    }

    public static ushort width(WC code, ElementKind ekind)
    {
        var result = width(code);
        if(result != 0)
            return result;

        switch(ekind)
        {
            case EK.U8:
            case EK.I8:
                result = 8;
                break;

            case EK.U16:
            case EK.I16:
            case EK.F16:
            case EK.F16x2:
            case EK.BF16:
                result = 16;
                break;

            case EK.U32:
            case EK.I32:
            case EK.F32:
            case EK.INT:
            case EK.UINT:
                result = 32;
                break;

            case EK.U64:
            case EK.I64:
            case EK.F64:
                result = 64;
                break;

            case EK.B80:
            case EK.F80:
                result = 80;
                break;

            case EK.U128:
                result = 128;
                break;

            case EK.U256:
                result = 256;
                break;
            default:
            break;
        }

        return result;
    }

    [Op]
    public static ushort width(XedRegId src)
        => (ushort)XedRegMap.Service.Map(src).Size.Width;

    [Op]
    public static ushort width(AsmVL src)
        => src switch
        {
            AsmVL.VL128 => 128,
            AsmVL.VL256 => 256,
            AsmVL.VL512 => 512,
            _ => 0
        };

    [Op]
    public static ushort width(OSZ src)
        => src switch
        {
            OSZ.o16=> 16,
            OSZ.o32=> 32,
            OSZ.o64=> 64,
            _ => 0
        };

    [MethodImpl(Inline)]
    public static ushort width(PointerWidthKind src)
        => src == 0 ? z16 : (ushort)((ushort)src * 8);

    [Op]
    public static uint bitwidth(EOSZ src)
        => src switch
        {
            EOSZAll => 8,
            EOSZ16 => 16,
            EOSZ32 => 32,
            EOSZ64 => 64,
            _ => 0,
        };

    [Op]
    public static uint width(EASZ src)
        => src switch
        {
            EASZ16 => 16,
            EASZ32 => 32,
            EASZ64 => 64,
            _ => 0,
        };

    [Op]
    public static uint width(MachineModeClass src)
        => src switch
        {
            Mode16 => 16,
            Mode32 => 32,
            Mode64 => 64,
            _ => 0,
        };


    [Op]
    public static uint width(DispWidth src)
        => src switch
        {
            DW8 => 8,
            DW16 => 16,
            DW32 => 32,
            DW64 => 64,
            _ => 0,
        };

    static ushort width(WC code)
    {
        var result = z16;
        switch(code)
        {
            case WC.B:
                result = 8;
            break;

            case WC.D:
                result = 32;
            break;

            case WC.MSKW:
            case WC.ZMSKW:
            case WC.I1:
                result = 1;
            break;
            case WC.I2:
                result = 2;
            break;
            case WC.I3:
                result = 3;
            break;
            case WC.I4:
                result = 4;
            break;
            case WC.I5:
                result = 5;
            break;
            case WC.I6:
                result = 6;
            break;
            case WC.I7:
                result = 7;
            break;
            case WC.I8:
                result = 8;
            break;

            case WC.MEM16:
            case WC.MEM16INT:
                result = 16;
                break;

            case WC.MEM28:
                result = 224;
                break;

            case WC.MEM14:
                result=112;
            break;

            case WC.MEM94:
                result=94;
            break;

            case WC.MEM108:
                result=108;
            break;

            case WC.M512:
                result = 512;
                break;

            case WC.M384:
                result = 384;
                break;

            case WC.MFPXENV:
                result = 4096;
            break;

            case WC.MXSAVE:
                result = 4608;
            break;
        }

        return result;
    }

    public XedWidths(ConstLookup<WidthCode,OpWidthDetail> src)
    {
        CodedWidths = src;
        WidthDetail = src.Values.ToArray().Sort();

        PointerWidths = map(Symbols.index<PointerWidthKind>().View, s => (PointerWidth)s.Kind);
        _Specs = OpWidthSpec.specs(WidthDetail);
    }

    readonly OpWidthSpecs _Specs;

    readonly ReadOnlySeq<OpWidthDetail> WidthDetail;

    readonly ConstLookup<WidthCode,OpWidthDetail> CodedWidths;

    readonly ReadOnlySeq<PointerWidth> PointerWidths;

    public ref readonly ReadOnlySeq<OpWidthDetail> Details => ref WidthDetail;

    public ref readonly ReadOnlySeq<PointerWidth> Pointers => ref PointerWidths;

    public ReadOnlySpan<WidthCode> Codes => Symbols.kinds<WidthCode>();

    public ref readonly OpWidthSpecs Specs => ref _Specs;

    public bool Detail(WidthCode code, out OpWidthDetail dst)
        => CodedWidths.Find(code, out dst);
}
