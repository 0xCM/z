//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vcpu;
    using static vpack;

    using C = AsciCode;

    [ApiHost]
    public readonly struct vtext
    {
        const NumericKind Closure = UInt64k;

        public static unsafe void decode(MemoryAddress src, uint size, out CharBlock32 dst)
        {
            var input = sys.cover(src.Pointer<byte>(), size);
            dst = CharBlock32.Null;
            var buffer = recover<ushort>(dst.Data);
            if(size == 32)
                vgcpu.vstore(vtext.decode(vcpu.vload(w256, input)), buffer);
            else
            {
                for(var i=0; i<size; i++)
                    seek(buffer,i) = skip(input,i);
            }
        }            

        [MethodImpl(Inline), Op]
        public static void decode(N48 n, ReadOnlySpan<byte> src, Span<char> dst)
        {
            ref var target = ref @as<ushort>(first(dst));
            var v = vload(w256, src);
            var offset = z8;
            vstore(vinflatelo256x16u(v), ref target);
            offset+=16;
            vstore(vinflatehi256x16u(v), ref seek(target,offset));
            offset+=16;
            decode(n16, sys.slice(src,offset), sys.slice(dst,offset));
        }

        [MethodImpl(Inline), Op]
        public static void decode(N16 n, ReadOnlySpan<byte> src, Span<char> dst)
            => vstore(vinflate256x16u(vcpu.vload(w128,src)), ref @as<ushort>(sys.first(dst)));

        [MethodImpl(Inline), Op]
        public static void decode(N32 n, ReadOnlySpan<byte> src, Span<char> dst)
        {
            ref var target = ref @as<ushort>(first(dst));
            var v = vload(w256, src);
            vstore(vinflatelo256x16u(v), ref target);
            vstore(vinflatehi256x16u(v), ref seek(target,16));
        }


        [MethodImpl(Inline), Op]
        public static Vector128<ushort> decode(ulong src)
            => vlo(vpack.vinflate256x16u(v8u(vscalar(src))));

        [MethodImpl(Inline), Op]
        public static Vector256<ushort> decode(Vector128<byte> src)
            => vpack.vinflate256x16u(src);

        [MethodImpl(Inline), Op]
        public static Vector512<ushort> decode(Vector256<byte> src)
            => vparts(w512, vpack.vinflatelo256x16u(src), vpack.vinflatehi256x16u(src));


        /// <summary>
        /// Populates the 16 components of an 128x8u vector with a specified character code
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector128<byte> broadcast(W128 w, char src)
            => vcpu.vbroadcast(w,(byte)src);

        /// <summary>
        /// Populates the 32 components of an 256x8u vector with a specified character code
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector256<byte> broadcast(W256 w, char src)
            => vcpu.vbroadcast(w,(byte)src);

        /// <summary>
        /// Populates the 16 components of an 128x8u vector with a specified character code
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector128<byte> broadcast(W128 w, C src)
            => vcpu.vbroadcast(w,(byte)src);

        /// <summary>
        /// Populates the 32 components of an 256x8u vector with a specified character code
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector256<byte> broadcast(W256 w, C src)
            => vcpu.vbroadcast(w,(byte)src);

        /// <summary>
        /// Populates the 8 components of a 128x16u vector with a specified character symbol
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector128<ushort> broadcast(W128 w, AsciCharSym src)
            => vcpu.vbroadcast(w,(ushort)src);

        /// <summary>
        /// Populates the 16 components of a 256x16u vector with a specified character symbol
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector256<ushort> broadcast(W256 w, AsciCharSym src)
            => vcpu.vbroadcast(w,(ushort)src);
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