//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct NumericFormats
    {
        [MethodImpl(Inline), Op,Closures(Integers)]
        public static string format<T>(T src, Base2 b, int? digits = null)
            where T : unmanaged
                => format_u(src,b, digits);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static string format<T>(T src, Base8 b, int? digits = null)
            where T : unmanaged
                => format_u(src,b, digits);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static string format<T>(T src, Base16 b, int? digits = null)
            where T : unmanaged
                => format_u(src,b, digits);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static string format<T>(T src, Base10 b, int? digits = null)
            where T : unmanaged
                => format_u(src,b, digits);

        [MethodImpl(Inline), Op]
        public static string format(sbyte src, Base2 b, int? digits = null)
            => BitRender.gformat(src, digits);

        [MethodImpl(Inline), Op]
        public static string format(sbyte src, Base8 b, int? digits = null)
            => Convert.ToString(src, 8);

        [MethodImpl(Inline), Op]
        public static string format(sbyte src, Base10 b, int? digits = null)
            => src.ToString();

        [MethodImpl(Inline), Op]
        public static string format(sbyte src, Base16 b, int? digits = null)
            => src.FormatHex(false, false);

        [MethodImpl(Inline), Op]
        public static string format(byte src, Base2 @base, int? digits = null)
            => BitRender.gformat(src, digits);

        [MethodImpl(Inline), Op]
        public static string format(byte src, Base8 @base, int? digits = null)
            => Convert.ToString(src, 8);

        [MethodImpl(Inline), Op]
        public static string format(byte src, Base10 @base, int? digits = null)
            => src.ToString();

        [MethodImpl(Inline), Op]
        public static string Format(byte src, Base16 @base, int? digits = null)
            => src.FormatHex(false, false);

        [MethodImpl(Inline), Op]
        public static string format(short src, Base2 @base, int? digits = null)
            => BitRender.gformat(src, digits);

        [MethodImpl(Inline), Op]
        public static string format(short src, Base8 @base, int? digits = null)
            => Convert.ToString(src,8);

        [MethodImpl(Inline), Op]
        public static string Format(short src, Base10 @base, int? digits = null)
            => src.ToString();

        [MethodImpl(Inline), Op]
        public static string Format(short src, Base16 @base, int? digits = null)
            => src.FormatHex(false, false);

        [MethodImpl(Inline), Op]
        public static string format(ushort src, Base2 @base, int? digits = null)
            => BitRender.gformat(src,digits);

        [MethodImpl(Inline), Op]
        public static string format(ushort src, Base8 @base, int? digits = null)
            => Convert.ToString(src,8);

        [MethodImpl(Inline), Op]
        public static string format(ushort src, Base10 @base, int? digits = null)
            => src.ToString();

        [MethodImpl(Inline), Op]
        public static string format(ushort src, Base16 @base, int? digits = null)
            => src.FormatHex(false, false);

        [MethodImpl(Inline), Op]
        public static string format(int src, Base2 @base, int? digits = null)
            => BitRender.gformat(src,digits);

        [MethodImpl(Inline), Op]
        public static string Format(int src, Base8 @base, int? digits = null)
            => Convert.ToString(src,8);

        [MethodImpl(Inline), Op]
        public static string Format(int src, Base10 @base, int? digits = null)
            => src.ToString();

        [MethodImpl(Inline), Op]
        public static string format(int src, Base16 @base, int? digits = null)
            => src.FormatHex(false, false);

        [MethodImpl(Inline), Op]
        public static string format(uint src, Base2 @base, int? digits = null)
            => BitRender.gformat(src,digits);

        [MethodImpl(Inline), Op]
        public static string format(uint src, Base8 @base, int? digits = null)
            => Convert.ToString(src,8);

        [MethodImpl(Inline), Op]
        public static string Format(uint src, Base10 @base, int? digits = null)
            => src.ToString();

        [MethodImpl(Inline), Op]
        public static string Format(uint src, Base16 @base, int? digits = null)
            => src.FormatHex(false, false);

        [MethodImpl(Inline), Op]
        public static string Format(long src, Base2 @base, int? digits = null)
            => BitRender.gformat(src,digits);

        [MethodImpl(Inline), Op]
        public static string format(long src, Base8 @base, int? digits = null)
            => Convert.ToString(src,8);

        [MethodImpl(Inline), Op]
        public static string format(long src, Base10 @base, int? digits = null)
            => src.ToString();

        [MethodImpl(Inline), Op]
        public static string format(long src, Base16 @base, int? digits = null)
            => src.FormatHex(false, false);

        [MethodImpl(Inline), Op]
        public static string format(ulong src, Base2 @base, int? digits = null)
            => BitRender.gformat(src, digits);

        [MethodImpl(Inline), Op]
        public static string format(ulong src, Base8 @base, int? digits = null)
            => Convert.ToString((long)src,8);

        [MethodImpl(Inline), Op]
        public static string format(ulong src, Base10 @base, int? digits = null)
            => src.ToString();

        [MethodImpl(Inline), Op]
        public static string format(ulong src, Base16 @base, int? digits = null)
            => src.FormatHex(false, false);

        [MethodImpl(Inline), Op]
        public static string format(ulong src, Base2 @base, int? digits, bool specifier)
            => (specifier ? "0b" : EmptyString) + BitRender.gformat(src, digits);

        [MethodImpl(Inline), Op]
        public static string format(ulong src, Base8 @base, int? digits, bool specifier)
            => Convert.ToString((long)src,8);

        [MethodImpl(Inline), Op]
        public static string format(ulong src, Base10 @base, int? digits, bool specifier)
            => src.ToString();

        [MethodImpl(Inline), Op]
        public static string format(ulong src, Base16 @base, int? digits, bool specifier)
            => src.FormatHex(false, specifier, prespec: specifier);

        [MethodImpl(Inline), Op]
        public static string format(sbyte src, NumericBaseKind @base, int? digits = null)
           => @base switch{
               NumericBaseKind.Base2 => format(src, base2, digits),
               NumericBaseKind.Base8 => format(src, base8, digits),
               NumericBaseKind.Base16 => format(src, base16, digits),
                _ => format(src, base10, digits),
            };

        [MethodImpl(Inline), Op]
        public static string format(byte src, NumericBaseKind @base, int? digits = null)
           => @base switch{
               NumericBaseKind.Base2 => format(src, base2, digits),
               NumericBaseKind.Base8 => format(src, base8, digits),
               NumericBaseKind.Base16 => Format(src, base16, digits),
                _ => format(src, base10, digits),
            };

        [MethodImpl(Inline), Op]
        public static string format(short src, NumericBaseKind @base, int? digits = null)
           => @base switch{
               NumericBaseKind.Base2 => format(src, base2, digits),
               NumericBaseKind.Base8 => format(src, base8, digits),
               NumericBaseKind.Base16 => Format(src, base16, digits),
                _ => Format(src, base10, digits),
            };

        [MethodImpl(Inline), Op]
        public static string format(ushort src, NumericBaseKind @base, int? digits = null)
           => @base switch{
               NumericBaseKind.Base2 => format(src, base2, digits),
               NumericBaseKind.Base8 => format(src, base8, digits),
               NumericBaseKind.Base16 => format(src, base16, digits),
                _ => format(src, base10, digits),
            };

        [MethodImpl(Inline), Op]
        public static string Format(int src, NumericBaseKind @base, int? digits = null)
           => @base switch{
               NumericBaseKind.Base2 => format(src, base2, digits),
               NumericBaseKind.Base8 => Format(src, base8, digits),
               NumericBaseKind.Base16 => format(src, base16, digits),
                _ => Format(src, base10, digits),
            };

        [MethodImpl(Inline), Op]
        public static string Format(uint src, NumericBaseKind @base, int? digits = null)
           => @base switch{
               NumericBaseKind.Base2 => format(src, base2, digits),
               NumericBaseKind.Base8 => format(src, base8, digits),
               NumericBaseKind.Base16 => Format(src, base16, digits),
                _ => Format(src, base10, digits),
            };

        [MethodImpl(Inline), Op]
        public static string format(long src, NumericBaseKind @base, int? digits = null)
           => @base switch{
               NumericBaseKind.Base2 => Format(src, base2, digits),
               NumericBaseKind.Base8 => format(src, base8, digits),
               NumericBaseKind.Base16 => format(src, base16, digits),
                _ => format(src, base10, digits),
            };

        [MethodImpl(Inline), Op]
        public static string format(ulong src, NumericBaseKind @base, int? digits = null)
           => @base switch{
               NumericBaseKind.Base2 => format(src, base2, digits),
               NumericBaseKind.Base8 => format(src, base8, digits),
               NumericBaseKind.Base16 => format(src, base16, digits),
                _ => format(src, base10, digits),
            };

        [MethodImpl(Inline), Op]
        public static string format(ulong src, NumericBaseKind @base, int? digits, bool specifier)
           => @base switch{
               NumericBaseKind.Base2 => format(src, base2, digits, specifier),
               NumericBaseKind.Base8 => format(src, base8, digits, specifier),
               NumericBaseKind.Base16 => format(src, base16, digits, specifier),
                _ => format(src, base10, digits, specifier),
            };

        [MethodImpl(Inline)]
        static string format_u<T>(T src, Base10 b, int? digits = null)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return format(uint8(src),b, digits);
            else if(typeof(T) == typeof(ushort))
                return format(uint16(src),b, digits);
            else if(typeof(T) == typeof(uint))
                return Format(uint32(src),b, digits);
            else if(typeof(T) == typeof(ulong))
                return format(uint64(src),b, digits);
            else
                return format_i(src,b, digits);
        }

        [MethodImpl(Inline)]
        static string format_i<T>(T src, Base10 b, int? digits = null)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return format(int8(src), b, digits);
            else if(typeof(T) == typeof(short))
                return Format(int16(src), b, digits);
            else if(typeof(T) == typeof(int))
                return Format(int32(src), b, digits);
            else if(typeof(T) == typeof(long))
                return format(int64(src), b, digits);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static string format_u<T>(T src, Base16 b, int? digits = null)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return Format(uint8(src),b, digits);
            else if(typeof(T) == typeof(ushort))
                return format(uint16(src),b, digits);
            else if(typeof(T) == typeof(uint))
                return Format(uint32(src),b, digits);
            else if(typeof(T) == typeof(ulong))
                return format(uint64(src),b, digits);
            else
                return format_i(src, b, digits);
        }

        [MethodImpl(Inline)]
        static string format_i<T>(T src, Base16 n, int? digits = null)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return format(int8(src), n, digits);
            else if(typeof(T) == typeof(short))
                return Format(int16(src), n, digits);
            else if(typeof(T) == typeof(int))
                return format(int32(src), n, digits);
            else if(typeof(T) == typeof(long))
                return format(int64(src), n, digits);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static string format_u<T>(T src, Base2 n, int? digits = null)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return format(uint8(src),n, digits);
            else if(typeof(T) == typeof(ushort))
                return format(uint16(src),n, digits);
            else if(typeof(T) == typeof(uint))
                return format(uint32(src),n, digits);
            else if(typeof(T) == typeof(ulong))
                return format(uint64(src),n, digits);
            else
                return format_i(src, n, digits);
        }

        [MethodImpl(Inline)]
        static string format_i<T>(T src, Base2 n, int? digits = null)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return format(int8(src),n, digits);
            else if(typeof(T) == typeof(short))
                return format(int16(src),n, digits);
            else if(typeof(T) == typeof(int))
                return format(int32(src),n, digits);
            else if(typeof(T) == typeof(long))
                return Format(int64(src),n, digits);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static string format_u<T>(T src, Base8 n, int? digits = null)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return format(uint8(src),n, digits);
            else if(typeof(T) == typeof(ushort))
                return format(uint16(src),n, digits);
            else if(typeof(T) == typeof(uint))
                return format(uint32(src),n, digits);
            else if(typeof(T) == typeof(ulong))
                return format(uint64(src),n, digits);
            else
                return format_i(src,n, digits);
        }

        [MethodImpl(Inline)]
        static string format_i<T>(T src, Base8 n, int? digits = null)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return format(int8(src), n, digits);
            else if(typeof(T) == typeof(short))
                return format(int16(src), n, digits);
            else if(typeof(T) == typeof(int))
                return Format(int32(src), n, digits);
            else if(typeof(T) == typeof(long))
                return format(int64(src), n, digits);
            else
                throw no<T>();
        }
    }
}