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
            => api.gformat(src, config ?? BitFormatter.configure());

        public static string FormatBits(this sbyte src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormatter.configure());

        public static string FormatBits(this short src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormatter.configure());

        public static string FormatBits(this ushort src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormatter.configure());

        public static string FormatBits(this uint src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormatter.configure());

        public static string FormatBits(this int src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormatter.configure());

        public static string FormatBits(this ulong src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormatter.configure());

        public static string FormatBits(this long src, BitFormat? config = null)
            => api.gformat(src, config ?? BitFormatter.configure());

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


    }
}