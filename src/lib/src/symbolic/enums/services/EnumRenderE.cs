//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Enums;

    using M = EnumFormatMode;
    using F = NumericFormats;
    using K = ClrEnumCode;

    public class EnumRender
    {
        public static string format<E>(E src, EnumFormatMode mode = EnumFormatMode.Expr)
            where E : unmanaged, Enum
                => EnumRender<E>.Service.Format(src, mode);

        public static string format<E>(E src, Base2 n, int? digits = null)
            where E : unmanaged, Enum
                => ecode<E>() switch {
                    K.U8 => F.format(e8u(src), n, digits),
                    K.I8 => F.format(e8i(src), n, digits),
                    K.I16 => F.format(e16i(src), n, digits),
                    K.U16 => F.format(e16u(src), n, digits),
                    K.I32 => F.format(e32i(src), n, digits),
                    K.U32 => F.format(e32u(src), n, digits),
                    K.I64 => F.Format(e64i(src), n, digits),
                    K.U64 => F.format(e64u(src), n, digits),
                    _ => src.ToString(),
                };

        public static string format<E>(E src, Base8 n, int? digits = null)
            where E : unmanaged, Enum
                => ecode<E>() switch {
                    K.U8 => F.format(e8u(src), n, digits),
                    K.I8 => F.format(e8i(src), n, digits),
                    K.I16 => F.format(e16i(src), n, digits),
                    K.U16 => F.format(e16u(src), n, digits),
                    K.I32 => F.Format(e32i(src), n, digits),
                    K.U32 => F.format(e32u(src), n, digits),
                    K.I64 => F.format(e64i(src), n, digits),
                    K.U64 => F.format(e64u(src), n, digits),
                    _ => src.ToString(),
                };

        public static string format<E>(E src, Base16 n, int? digits = null)
            where E : unmanaged, Enum
                => ecode<E>() switch {
                    K.U8 => F.Format(e8u(src), n, digits),
                    K.I8 => F.format(e8i(src), n, digits),
                    K.I16 => F.Format(e16i(src), n, digits),
                    K.U16 => F.format(e16u(src), n, digits),
                    K.I32 => F.format(e32i(src), n, digits),
                    K.U32 => F.Format(e32u(src), n, digits),
                    K.I64 => F.format(e64i(src), n, digits),
                    K.U64 => F.format(e64u(src), n, digits),
                    _ => src.ToString(),
                };

        public static string format<E>(E src, Base10 b, int? digits = null)
            where E : unmanaged, Enum
                => ecode<E>() switch {
                    K.U8 => F.format(e8u(src), b, digits),
                    K.I8 => F.format(e8i(src), b, digits),
                    K.I16 => F.Format(e16i(src), b, digits),
                    K.U16 => F.format(e16u(src), b, digits),
                    K.I32 => F.Format(e32i(src), b, digits),
                    K.U32 => F.Format(e32u(src), b, digits),
                    K.I64 => F.format(e64i(src), b, digits),
                    K.U64 => F.format(e64u(src), b, digits),
                    _ => src.ToString(),
                };

        public static string format<E>(E src, NumericBaseKind b, int? digits = null)
            where E : unmanaged, Enum
                => ecode<E>() switch {
                    K.U8 => F.format(e8u(src), b, digits),
                    K.I8 => F.format(e8i(src), b, digits),
                    K.I16 => F.format(e16i(src), b, digits),
                    K.U16 => F.format(e16u(src), b, digits),
                    K.I32 => F.Format(e32i(src), b, digits),
                    K.U32 => F.Format(e32u(src), b, digits),
                    K.I64 => F.format(e64i(src), b, digits),
                    K.U64 => F.format(e64u(src), b, digits),
                    _ => src.ToString(),
                };

        public static string format<E>(EnumRender<E> render, E src, DataFormatCode fc)
            where E : unmanaged, Enum
        {
            var dst = EmptyString;
            switch(fc)
            {
                case DataFormatCode.SInt:
                    dst = ((int)bw32(src)).ToString();
                break;
                case DataFormatCode.Hex:
                    dst = bw32(src).FormatHex();
                break;
                case DataFormatCode.UInt:
                    dst = bw32(src).ToString();
                break;
                case DataFormatCode.Name:
                    dst = render.Format(src, true);
                break;
                default:
                    dst = render.Format(src);
                break;
            }
            return dst;
        }
    }

    public readonly struct EnumRender<E> : ITextFormatter<E>
        where E : unmanaged, Enum
    {
        public static EnumRender<E> Service = new();

        public string Format(E src)
        {
            if(Syms.MapKind(src, out var a))
                return a.Expr.Text;
            else if(Syms.MapValue(core.bw64(src), out var b))
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
                else if(Syms.MapValue(core.bw64(src), out var b))
                    return b.Name;
                else
                    return RP.Error;
            }
            else
                return Format(src);
        }

        public string Format(E src, EnumFormatMode mode)
        {
            if(mode.Test(M.EmptyZero)  && core.bw64(src) == 0)
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
                    dst = ((ulong)e.Value).FormatBits(BF);
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
            BF = new BitFormat(tlz:true,specifier:true);
        }
    }
}