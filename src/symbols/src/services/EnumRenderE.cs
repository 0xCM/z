//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using M = EnumFormatMode;

public readonly struct EnumRender<E> : ITextFormatter<E>
    where E : unmanaged, Enum
{
    public static EnumRender<E> Service = new();

    public string Format(E src)
    {
        if(Syms.MapKind(src, out var a))
            return a.Expr.Text;
        else if(Syms.MapValue(sys.bw64(src), out var b))
            return b.Expr.Text;
        else
            return RP.Error;
    }

    public string Format(E src, bool name)
    {
        if(name)
        {
            if(Syms.MapKind(src, out var a))
                return a.Name;
            else if(Syms.MapValue(bw64(src), out var b))
                return b.Name;
            else
                return RP.Error;
        }
        else
            return Format(src);
    }

    public string Format(E src, M mode)
    {
        if(mode.Test(M.EmptyZero)  && bw64(src) == 0)
            return EmptyString;

        var dst = RP.Error;
        Syms.MapKind(src, out var e);

        switch((EnumFormatMode)((byte)mode & 0b111111))
        {
            case M.Expr:
                dst = e.Expr.Text;
            break;
            case M.Name:
                dst = e.Name;
            break;
            case M.Base10:
                dst = ((ulong)e.Value).ToString();
            break;
            case M.Base2:
                dst = text.bits(sys.bytes((ulong)e.Value), BF);
            break;
            case M.Base16:
                dst = ((ulong)e.Value).FormatHex(zpad:false);
            break;
            default:
                dst = e.Expr.Text;
            break;
        }
        return dst;
    }

    static readonly Symbols<E> Syms;

    static readonly BitFormat BF;

    static EnumRender()
    {
        Syms = Symbols.index<E>();
        BF = new BitFormat(tlz:true, specifier:true);
    }
}
