//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vcpu;
    using static vpack;

    [ApiHost]
    public readonly struct vtext
    {
        const NumericKind Closure = UInt64k;

        /// <summary>
        /// Copies the source to the target using 128-bit intrinsic operations
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void copy<T>(W128 w, ReadOnlySpan<T> src, Span<T> dst)
            where T : unmanaged
        {
            var seg = (uint)vcount<T>(w);
            var length = src.Length;
            var blocks = length/seg;
            var rem = length % seg;
            for(var i=0u; i<blocks; i++)
            {
                var offset = i*seg;
                var vSrc = vgcpu.vload(w, skip(src, offset));
                vgcpu.vstore(vSrc, ref seek(dst,offset));
            }

            for(var i=blocks; i<length; i++)
                seek(dst,i) = skip(src,i);
        }

        /// <summary>
        /// Copies the source to the target using 256-bit intrinsic operations
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void copy<T>(W256 w, ReadOnlySpan<T> src, Span<T> dst)
            where T : unmanaged
        {
            var seg = (uint)vcount<T>(w);
            var length = src.Length;
            var blocks = length/seg;
            var rem = length % seg;
            for(var i=0u; i<blocks; i++)
            {
                var offset = i*seg;
                var vSrc = vgcpu.vload(w, skip(src, offset));
                vgcpu.vstore(vSrc, ref seek(dst,offset));
            }

            for(var i=blocks; i<length; i++)
                seek(dst,i) = skip(src,i);
        }

        [MethodImpl(Inline), Op]
        public static void pack(N16 n, ReadOnlySpan<char> src, Span<byte> dst)
            => vcpu.vstore(vpack128x8u(vload(w256, first(src))), ref first(dst));

        [MethodImpl(Inline), Op]
        public static void pack(N32 n, ReadOnlySpan<char> src, Span<byte> dst)
        {
            ref readonly var c0 = ref first(src);
            ref var b0 = ref first(dst);
            vcpu.vstore(vpack128x8u(vload(w256, c0)), ref b0);
            ref readonly var c1 = ref skip(first(src),16);
            ref var b1 = ref seek(u8(dst),16);
            vcpu.vstore(vpack128x8u(vload(w256, c1)), ref b1);
        }

        [MethodImpl(Inline), Op]
        public static void pack(N64 n, ReadOnlySpan<char> src, Span<byte> dst)
        {
            ref readonly var c0 = ref first(src);
            ref var b0 = ref first(dst);
            vcpu.vstore(vpack128x8u(vload(w256, c0)), ref b0);
            ref readonly var c1 = ref skip(first(src),16);
            ref var b1 = ref seek(u8(dst),16);
            vcpu.vstore(vpack128x8u(vload(w256, c1)), ref b1);
            ref readonly var c2 = ref skip(first(src),32);
            ref var b2 = ref seek(u8(dst),32);
            vcpu.vstore(vpack128x8u(vload(w256, c2)), ref b2);
            ref readonly var c3 = ref skip(first(src),48);
            ref var b3 = ref seek(u8(dst),48);
            vcpu.vstore(vpack128x8u(vload(w256, c3)), ref b3);
        }

        [MethodImpl(Inline), Op]
        public static void unpack(N32 n, ReadOnlySpan<byte> src, Span<char> dst)
        {
            var packed = vload(w256, src);
            var unpacked = new Vector512<ushort>(vinflatelo256x16u(packed), vinflatehi256x16u(packed));
            var source = v8u(unpacked);
            var target = bytes(dst);
            vcpu.vstore(source, target);
        }

        [MethodImpl(Inline), Op]
        public static void bits(Vector128<byte> src, Span<char> dst)
        {
            var a = vinflate256x8u(vcell(src,1), 0);
            var lo = vlo256x16u(a);
            ref var target = ref u16(first(dst));
            vcpu.vstore(lo, ref seek(target,0));
            var hi = vhi256x16u(a);
            vcpu.vstore(hi, ref seek(target,16));
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
                => dst.Append(vgcpu.vspan(src).FormatHex(Chars.Space, false));

        [Op, Closures(Closure)]
        public static void asmhex<T>(Vector256<T> src, ITextBuffer dst)
            where T : unmanaged
            => dst.Append(vgcpu.vspan(src).FormatHex(Chars.Space, false));

        [Op, Closures(Closure)]
        public static void asmhex<T>(Vector512<T> src, ITextBuffer dst)
            where T : unmanaged
                => dst.Append(vgcpu.vspan(src).FormatHex(Chars.Space, false));

        [Op, Closures(Closure)]
        public static void hex<T>(Vector128<T> src, ITextBuffer dst,  char sep = Chars.Comma, bool specifier = false)
            where T : unmanaged
                => dst.Append(vgcpu.vspan(src).FormatHex(sep, specifier));

        [Op, Closures(Closure)]
        public static void hex<T>(Vector256<T> src, ITextBuffer dst, char sep = Chars.Comma, bool specifier = false)
             where T : unmanaged
                => dst.Append(vgcpu.vspan(src).FormatHex(sep, specifier));

        [Op, Closures(Closure)]
        public static void lanes<T>(Vector256<T> src, char sep, int pad, ITextBuffer dst)
            where T : unmanaged
                => dst.Append(string.Format("{0} {1}", src.GetLower().Format(sep, pad), src.GetUpper().Format(sep, pad)));
    }
}