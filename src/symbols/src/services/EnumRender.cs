//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static Enums;

using M = EnumFormatMode;
using F = NumericFormats;
using K = ClrEnumCode;

public class EnumRender
{
    public static string format<E>(E src, M mode = M.Expr)
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
                K.I64 => F.format(e64i(src), n, digits),
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
                K.I32 => F.format(e32i(src), n, digits),
                K.U32 => F.format(e32u(src), n, digits),
                K.I64 => F.format(e64i(src), n, digits),
                K.U64 => F.format(e64u(src), n, digits),
                _ => src.ToString(),
            };

    public static string format<E>(E src, Base16 n, int? digits = null)
        where E : unmanaged, Enum
            => ecode<E>() switch {
                K.U8 => F.format(e8u(src), n, digits),
                K.I8 => F.format(e8i(src), n, digits),
                K.I16 => F.format(e16i(src), n, digits),
                K.U16 => F.format(e16u(src), n, digits),
                K.I32 => F.format(e32i(src), n, digits),
                K.U32 => F.format(e32u(src), n, digits),
                K.I64 => F.format(e64i(src), n, digits),
                K.U64 => F.format(e64u(src), n, digits),
                _ => src.ToString(),
            };

    public static string format<E>(E src, Base10 b, int? digits = null)
        where E : unmanaged, Enum
            => ecode<E>() switch {
                K.U8 => F.format(e8u(src), b, digits),
                K.I8 => F.format(e8i(src), b, digits),
                K.I16 => F.format(e16i(src), b, digits),
                K.U16 => F.format(e16u(src), b, digits),
                K.I32 => F.format(e32i(src), b, digits),
                K.U32 => F.format(e32u(src), b, digits),
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

