//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using api = BitRender;

    partial class XTend
    {
        public static string FormatBits(this byte src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormat.configure());

        public static string FormatBits(this sbyte src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormat.configure());

        public static string FormatBits(this short src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormat.configure());

        public static string FormatBits(this ushort src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormat.configure());
        public static string FormatBits(this uint src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormat.configure());

        public static string FormatBits(this int src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormat.configure());

        public static string FormatBits(this ulong src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormat.configure());

        public static string FormatBits(this long src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormat.configure());

        public static string Format(this byte src, NumericBaseKind @base)
            => @base switch{
                NumericBaseKind.Base2 => src.FormatBits(),
                NumericBaseKind.Base16 => src.FormatHex(),
                _=> src.ToString(),
            };

        public static string Format(this ushort src, NumericBaseKind @base)
            => @base switch{
                NumericBaseKind.Base2 => src.FormatBits(),
                NumericBaseKind.Base16 => src.FormatHex(),
                _=> src.ToString(),
            };

        public static string Format(this uint src, NumericBaseKind @base)
            => @base switch{
                NumericBaseKind.Base2 => src.FormatBits(),
                NumericBaseKind.Base16 => src.FormatHex(),
                _=> src.ToString(),
            };

        public static string Format(this ulong src, NumericBaseKind @base)
            => @base switch{
                NumericBaseKind.Base2 => src.FormatBits(),
                NumericBaseKind.Base16 => src.FormatHex(),
                _=> src.ToString(),
            };

        public static string FormatBits<T>(this ReadOnlySpan<T> src, BitFormat? config = null)
            where T : unmanaged
                => api.gformat(src, config);

        public static string FormatBits<T>(this Span<T> src, BitFormat? config = null)
            where T : unmanaged
                => api.gformat(src.ReadOnly(), config);

        [Op]
        public static string FormatBits(this Hex2 src)
            => BitRender.format2(src);

        [Op]
        public static string FormatBits(this Hex3 src)
            => BitRender.format3(src);

        [Op]
        public static string FormatBits(this Hex4 src)
            => BitRender.format4(src);

        [Op]
        public static string FormatBits(this Hex5 src)
            => BitRender.format5(src);

        [Op]
        public static string FormatBits(this Hex6 src)
            => BitRender.format6(src);

        [Op]
        public static string FormatBits(this Hex7 src)
            => BitRender.format7(src);

        [Op]
        public static string FormatBits(this Hex8 src, N4 n)
            => BitRender.format8x4(src);

        [Op]
        public static string FormatBits(this Hex8 src, N8 n)
            => BitRender.format8(src);

        [Op]
        public static string FormatBits(this Hex16 src, N4 n)
            => BitRender.format16x4(src);

        [Op]
        public static string FormatBits(this Hex16 src, N8 n)
            => BitRender.format16x8(src);

        [Op]
        public static string FormatBits(this Hex32 src, N4 n)
            => BitRender.format32x4(src);

        [Op]
        public static string FormatBits(this Hex32 src, N8 n)
            => BitRender.format32x8(src);

        [Op]
        public static string FormatBits(this Hex64 src, N4 n)
            => BitRender.format64x4(src);

        [Op]
        public static string FormatBits(this Hex64 src, N8 n)
            => BitRender.format64x8(src);
    }
}