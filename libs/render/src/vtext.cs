//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static cpu;
    using static vpack;

    [ApiHost]
    public readonly struct vtext
    {
        const NumericKind Closure = UInt64k;

        [MethodImpl(Inline), Op]
        public static void pack(N16 n, ReadOnlySpan<char> src, Span<byte> dst)
            => vstore(vpack128x8u(vload(w256, first(src))), ref first(dst));

        [MethodImpl(Inline), Op]
        public static void pack(N32 n, ReadOnlySpan<char> src, Span<byte> dst)
        {
            ref readonly var c0 = ref first(src);
            ref var b0 = ref first(dst);
            vstore(vpack128x8u(vload(w256, c0)), ref b0);
            ref readonly var c1 = ref skip(first(src),16);
            ref var b1 = ref seek(u8(dst),16);
            vstore(vpack128x8u(vload(w256, c1)), ref b1);
        }

        [MethodImpl(Inline), Op]
        public static void pack(N64 n, ReadOnlySpan<char> src, Span<byte> dst)
        {
            ref readonly var c0 = ref first(src);
            ref var b0 = ref first(dst);
            vstore(vpack128x8u(vload(w256, c0)), ref b0);
            ref readonly var c1 = ref skip(first(src),16);
            ref var b1 = ref seek(u8(dst),16);
            vstore(vpack128x8u(vload(w256, c1)), ref b1);
            ref readonly var c2 = ref skip(first(src),32);
            ref var b2 = ref seek(u8(dst),32);
            vstore(vpack128x8u(vload(w256, c2)), ref b2);
            ref readonly var c3 = ref skip(first(src),48);
            ref var b3 = ref seek(u8(dst),48);
            vstore(vpack128x8u(vload(w256, c3)), ref b3);
        }

        [MethodImpl(Inline), Op]
        public static void unpack(N32 n, ReadOnlySpan<byte> src, Span<char> dst)
        {
            var packed = vload(w256, src);
            var unpacked = new Vector512<ushort>(vinflatelo256x16u(packed), vinflatehi256x16u(packed));
            var source = v8u(unpacked);
            var target = bytes(dst);
            vstore(source, target);
        }

        [MethodImpl(Inline), Op]
        public static void bits(Vector128<byte> src, Span<char> dst)
        {
            var a = vinflate256x8u(vcell(src,1), 0);
            var lo = vlo256x16u(a);
            ref var target = ref u16(first(dst));
            vstore(lo, ref seek(target,0));
            var hi = vhi256x16u(a);
            vstore(hi, ref seek(target,16));
        }

        [MethodImpl(Inline), Op]
        public static void copy(N16 n, ReadOnlySpan<char> src, Span<char> dst)
            => vstore(vload(w128, u8(first(src))), @bytes(dst));

        [MethodImpl(Inline), Op]
        public static void copy(N32 n, ReadOnlySpan<char> src, Span<char> dst)
        {
            ref readonly var _u8Src = ref u8(first(src));
            ref var _u8Dst = ref @as<byte>(first(dst));
            vstore(vload(w256, _u8Src), ref _u8Dst);
            vstore(vload(w256, skip(_u8Src,32)), ref seek(_u8Dst, 32));
        }

        [Op, Closures(Closure)]
        public static void asmhex<T>(Vector128<T> src, ITextBuffer dst)
            where T : unmanaged
                => dst.Append(gcpu.vspan(src).FormatHex(Chars.Space, false));

        [Op, Closures(Closure)]
        public static void asmhex<T>(Vector256<T> src, ITextBuffer dst)
            where T : unmanaged
            => dst.Append(gcpu.vspan(src).FormatHex(Chars.Space, false));

        [Op, Closures(Closure)]
        public static void asmhex<T>(Vector512<T> src, ITextBuffer dst)
            where T : unmanaged
                => dst.Append(gcpu.vspan(src).FormatHex(Chars.Space, false));

        [Op, Closures(Closure)]
        public static void hex<T>(Vector128<T> src, ITextBuffer dst,  char sep = Chars.Comma, bool specifier = false)
            where T : unmanaged
                => dst.Append(gcpu.vspan(src).FormatHex(sep, specifier));

        [Op, Closures(Closure)]
        public static void hex<T>(Vector256<T> src, ITextBuffer dst, char sep = Chars.Comma, bool specifier = false)
             where T : unmanaged
                => dst.Append(gcpu.vspan(src).FormatHex(sep, specifier));

        [Op, Closures(Closure)]
        public static void outcome<T>(SpanBlock128<T> x, SpanBlock128<T> y, Vector128<T> expect, Vector128<T> actual, Vector128<T> result, ITextBuffer dst)
            where T : unmanaged
        {
            dst.Label("left", Chars.Colon, x.Format());
            dst.Label("right", Chars.Colon, y.Format());
            dst.Label("expect", Chars.Colon, expect.Format());
            dst.Label("actual", Chars.Colon, actual.Format());
            dst.Label("result", Chars.Colon, result.Format());
        }

        [Op, Closures(Closure)]
        public static void outcome<T>(SpanBlock256<T> x, SpanBlock256<T> y, Vector256<T> expect, Vector256<T> actual, Vector256<T> result, ITextBuffer dst)
            where T : unmanaged
        {
            dst.Label("left", Chars.Colon, x.Format());
            dst.Label("right", Chars.Colon, y.Format());
            dst.Label("expect", Chars.Colon, expect.Format());
            dst.Label("actual", Chars.Colon, actual.Format());
            dst.Label("result", Chars.Colon, result.Format());
        }

        [Op, Closures(Closure)]
        public static void lanes<T>(Vector256<T> src, char sep, int pad, ITextBuffer dst)
            where T : unmanaged
                => dst.Append(string.Format("{0} {1}", src.GetLower().Format(sep, pad), src.GetUpper().Format(sep, pad)));

       public static void projection<S,T>(Vector128<S> a, Vector128<T> b, ITextBuffer dst)
            where S : unmanaged
            where T : unmanaged
        {
            var srcType = TypeIdentity.numeric<S>();
            var srcCount = a.Length();
            var dstType = TypeIdentity.numeric<T>();
            var dstCount = b.Length();
            var srcWidth = srcCount * width<S>();
            var dstWidth = dstCount * width<T>();
            var srcLabel = $"v{srcWidth}x{srcType}";
            var dstLabel = $"v{dstWidth}x{dstType}";
            var label = $"{srcLabel}_{dstLabel}";
            var formatted = $"{label}:[{a.FormatHex()}] -> [{b.FormatHex()}]";
            dst.Append(formatted);
        }

        public static void projection<S,T>(SpanBlock64<S> a, Vector128<T> b, ITextBuffer dst)
            where S : unmanaged
            where T : unmanaged
        {
            var sep = Chars.Space;
            var srcType = TypeIdentity.numeric<S>();
            var srcCount = a.CellCount;
            var dstType = TypeIdentity.numeric<T>();
            var dstCount = b.Length();
            var srcWidth = srcCount * width<S>();
            var dstWidth = dstCount * width<T>();
            var srcLabel = $"m{srcWidth}x{srcType}";
            var dstLabel = $"v{dstWidth}x{dstType}";
            var label = $"{srcLabel}_{dstLabel}";
            var formatted = $"{label}:[{a.Storage.FormatHex(sep, false)}] -> [{b.FormatHex(sep, false)}]";
            dst.Append(formatted);
        }
    }
}