//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [Op, Closures(Closure)]
        public static string FormatHex<T>(this Vector128<T> src, char sep = Chars.Comma, bool specifier = false)
            where T : unmanaged
        {
            Span<byte> buffer = stackalloc byte[16];
            var dst = sys.recover<T>(buffer);
            vgcpu.vstore(src, dst);
            return HexFormatter.format(dst.ReadOnly(), sep, specifier);
        }

        [Op, Closures(Closure)]
        public static string FormatHex<T>(this Vector256<T> src, char sep = Chars.Comma, bool specifier = false)
             where T : unmanaged
        {
            Span<byte> buffer = stackalloc byte[32];
            var dst = sys.recover<T>(buffer);
            vgcpu.vstore(src, dst);
            return HexFormatter.format(dst.ReadOnly(), sep, specifier);
        }

        [Op, Closures(Closure)]
        public static string FormatHex<T>(this Vector512<T> src, char sep = Chars.Comma, bool specifier = false)
             where T : unmanaged
        {
            Span<byte> buffer = stackalloc byte[32];
            var dst = sys.recover<T>(buffer);
            vgcpu.vstore(src, dst);
            return HexFormatter.format(dst.ReadOnly(), sep, specifier);
        }

        [Op, Closures(Closure)]
        public static string Format<T>(this Vector128<T> src, char sep = Chars.Comma, int pad = 2)
            where T : unmanaged
                => vgcpu.vspan(src).FormatList(sep,0,pad,true);

        [Op, Closures(Closure)]
        public static string Format<T>(this Vector256<T> src, char sep = Chars.Comma, int pad = 2)
            where T : unmanaged
                => vgcpu.vspan(src).FormatList(sep, 0, pad, true);

        [Op, Closures(Closure)]
        public static string FormatLanes<T>(this Vector256<T> src, char sep = Chars.Comma, int pad = 2)
            where T : unmanaged
                => string.Concat(
                    src.GetLower().Format(sep, pad), Chars.Space,
                    src.GetUpper().Format(sep, pad));
   }
}