//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XBv
    {
        public static string FormatBlocked<T>(this ScalarBits<T> src, int width)
            where T : unmanaged
                => FormatBits.blocked(src.State, width);

        public static string FormatBlocked(this BitVector8 src, int width)
            => FormatBits.blocked(src.State, width);

        public static string FormatBlocked(this BitVector16 src, int width)
            => FormatBits.blocked(src.State, width);

        public static string FormatBlocked(this BitVector32 src, int width)
            => FormatBits.blocked(src.State, width);

        public static string FormatBlocked(this BitVector64 src, int width)
            => FormatBits.blocked(src.State, width);

        public static string FormatBlocked<T>(this ScalarBits<T> src, BitFormat config)
            where T : unmanaged
                => FormatBits.blocked(src.State, config);

        public static string FormatBlocked(this BitVector8 src, BitFormat config)
            => FormatBits.blocked(src.State, config);

        public static string FormatBlocked(this BitVector16 src, BitFormat config)
            => FormatBits.blocked(src.State, config);

        public static string FormatBlocked(this BitVector32 src, BitFormat config)
            => FormatBits.blocked(src.State, config);

        public static string FormatBlocked(this BitVector64 src, BitFormat config)
            => FormatBits.blocked(src.State, config);
    }
}