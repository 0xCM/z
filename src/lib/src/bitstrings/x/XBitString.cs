//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    using api = BitStrings;

    public static class XBitString
    {
        public static string FormatBlockedBits(this byte src, in BitFormat config)
            => api.blocked(src, config);

        public static string FormatBlockedBits(this ushort src, in BitFormat config)
            => api.blocked(src, config);

        public static string FormatBlockedBits(this uint src, in BitFormat config)
            => api.blocked(src, config);

        public static string FormatBlockedBits(this ulong src, in BitFormat config)
            => api.blocked(src, config);

        public static string FormatBlockedBits(this byte src, int width)
            => api.blocked(src, BitFormatter.blocked(width));

        public static string FormatBlockedBits(this ushort src, int width)
            => api.blocked(src, BitFormatter.blocked(width));

        public static string FormatBlockedBits(this uint src, int width)
            => api.blocked(src, BitFormatter.blocked(width));

        public static string FormatBlockedBits(this ulong src, int width)
            => api.blocked(src, BitFormatter.blocked(width));        
        /// <summary>
        /// Extracts a 128-bit cpu vector from a bitsring of sufficient length
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="w">The bit width selector</param>
        /// <param name="t">The component type representative</param>
        /// <typeparam name="T">The target vector component type</typeparam>
        [MethodImpl(Inline)]
        public static Vector128<T> ToCpuVector<T>(this BitString src, N128 w, T t = default)
            where T : unmanaged
                => src.Pack().Recover<byte,T>().Blocked(w).LoadVector();

        /// <summary>
        /// Extracts a 256-bit cpu vector from a bitsring of sufficient length
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="w">The bit width selector</param>
        /// <param name="t">The component type representative</param>
        /// <typeparam name="T">The target vector component type</typeparam>
        [MethodImpl(Inline)]
        public static Vector256<T> ToCpuVector<T>(this BitString src, N256 w, T t = default)
            where T : unmanaged
                => src.Pack().Recover<byte,T>().Blocked(w).LoadVector();

        /// <summary>
        /// Block-formats the vector, e.g. [01010101 01010101 ... 01010101] where by default the size of each block is the bit-width of a component
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The component type</typeparam>
        public static string FormatBlockedBits<T>(this Vector128<T> src, int width, uint? maxbits = null)
            where T : unmanaged
                => text.bracket(src.ToBitString((int?)maxbits).Format(BitFormatter.blocked(width, Chars.Space, maxbits)));

        /// <summary>
        /// Block-formats the vector, e.g. [01010101 01010101 ... 01010101] where default the size of each block is the bit-width of a component
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The component type</typeparam>
        public static string FormatBlockedBits<T>(this Vector256<T> src, int width, uint? maxbits = null)
            where T : unmanaged
                => text.bracket(src.ToBitString((int?)maxbits).Format(BitFormatter.blocked(width, Chars.Space, maxbits)));

        /// <summary>
        /// Formats vector bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
        public static string FormatBits<T>(this Vector128<T> src, int? maxbits = null,  bool tlz = false, bool specifier = false, int? blockWidth = null,
            char? blocksep = null, int? rowWidth = null)
                where T : unmanaged
                    => src.ToBitString(maxbits).Format(BitFormatter.define(tlz, specifier, blockWidth, blocksep, rowWidth,null));

        /// <summary>
        /// Formats vector bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
        public static string FormatBits<T>(this Vector256<T> src, int? maxbits = null, bool tlz = false, bool specifier = false, int? blockWidth = null,
            char? blocksep = null, int? rowWidth = null)
                where T : unmanaged
                    => src.ToBitString(maxbits).Format(BitFormatter.define(tlz, specifier, blockWidth, blocksep, rowWidth,null));
        /// <summary>
        /// Shuffles bitstring content as determined by a permutation
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="p">The permutation to apply</param>
        public static BitString Permute(this BitString src, Perm p)
        {
            var dst = api.alloc(p.Length);
            for(var i = 0; i<p.Length; i++)
                dst[i] = src[p[i]];
            return dst;
        }

        /// <summary>
        /// Pretends the source bitstring is an mxn matrix and computes the transposition matrix of dimension nxm encoded as a bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="m">The source row count</param>
        /// <param name="n">The source column count</param>
        public static BitString Transpose<M,N>(this BitString src, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => api.transpose(src, nat64u(m), nat64u(n));

        public static BitString Transpose(this BitString bs, int m, int n)
            => api.transpose(bs,m,n);

        public static BitString ToBitString(this string src)
            => api.parse(src);

        public static string Format(this Utf8Point src)
        {
            var bits = src.Code.FormatBits();
            var num = src.Code.FormatHex();
            var str = src.IsControl ? "___"  : $"'{src.ToChar()}'";
            return $"{num} {bits} {str}";
        }

        /// <summary>
        /// Converts the source value to a bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this sbyte src, uint? maxbits = null)
            => api.scalar(src, maxbits == null ? (int?)null : (int)maxbits.Value);

        /// <summary>
        /// Converts the source value to a bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this byte src, uint? maxbits = null)
            => api.scalar(src, maxbits == null ? (int?)null : (int)maxbits.Value);

        /// <summary>
        /// Converts the source value to a bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this short src, uint? maxbits = null)
            => api.scalar(src, maxbits == null ? (int?)null : (int)maxbits.Value);

        /// <summary>
        /// Converts the source value to a bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this ushort src, uint? maxbits = null)
            => api.scalar(src, maxbits == null ? (int?)null : (int)maxbits.Value);

        /// <summary>
        /// Converts the source value to a bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this int src, uint? maxbits = null)
            => api.scalar(src, maxbits == null ? (int?)null : (int)maxbits.Value);

        /// <summary>
        /// Converts the source value to a bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this uint src, uint? maxbits = null)
            => api.scalar(src, maxbits == null ? (int?)null : (int)maxbits.Value);

        /// <summary>
        /// Converts the source value to a bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this long src, uint? maxbits = null)
            => api.scalar(src, maxbits == null ? (int?)null : (int)maxbits.Value);

        /// <summary>
        /// Converts the source value to a bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this ulong src, uint? maxbits = null)
            => api.scalar(src, maxbits == null ? (int?)null : (int)maxbits.Value);

        /// <summary>
        /// Converts the source value to a bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this float src, int? maxbits = null)
            => api.scalar(src, maxbits);

        /// <summary>
        /// Converts the source value to a bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this double src, uint? maxbits = null)
            => api.scalar(src, maxbits == null ? (int?)null : (int)maxbits.Value);

        /// <summary>
        /// Converts span content to a to a bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this Span<T> src, int? maxbits = null)
            where T : unmanaged
                => api.scalars(src, maxbits);

        /// <summary>
        /// Converts blocked content to a bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this SpanBlock64<T> src, int? maxbits = null)
            where T : unmanaged
                => api.scalars(src.Storage, maxbits ?? w64);

        /// <summary>
        /// Converts blocked content to a bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this SpanBlock128<T> src, int? maxbits = null)
            where T : unmanaged
                => api.scalars(src.Storage, maxbits ?? w128);

        /// <summary>
        /// Converts datablock content to a bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this SpanBlock256<T> src, int? maxbits = null)
            where T : unmanaged
                => api.scalars(src.Storage, maxbits ?? w256);

        /// <summary>
        /// Converts an 128-bit intrinsic vector representation to a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this Vector128<T> src, int? maxbits = null)
            where T : unmanaged
                => api.load(src, maxbits);

        /// <summary>
        /// Converts an 256-bit vector representation to a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this Vector256<T> src, int? maxbits = null)
            where T : unmanaged
                => api.load(src, maxbits);

        /// <summary>
        /// Converts a 512-bit vector representation to a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this Vector512<T> src, int? maxbits = null)
            where T : unmanaged
                => api.load(src, maxbits);

        /// <summary>
        /// Converts an enumeration value to a bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The enumeration type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this T src, int? maxbits = null)
            where T : unmanaged, Enum
                => api.@enum(src, maxbits);

        /// <summary>
        /// Reverses the order of the source bits
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitString Reverse(this BitString src)
        {
            src.BitSeq.Reverse();
            return src;
        }

        /// <summary>
        /// Extracts the even bits
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString Even(this BitString src)
            => api.even(src);

        /// <summary>
        /// Extracts the odd bits
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString Odd(this BitString src)
            => api.odd(src);

        [MethodImpl(Inline)]
        public static BitString Intersperse(this BitString src, BitString value)
            => api.intersperse(src,value);

        [MethodImpl(Inline)]
        public static BitString Clear(ref this BitString src, int i0, int i1)
            => api.clear(ref src, i0, i1);

        [MethodImpl(Inline)]
        public static BitString BitMap(ref this BitString dst, BitString src, int start, int len)
            => api.inject(src,ref dst, start, len);

        [MethodImpl(Inline)]
        public static BitString Not(this BitString bs)
            => api.not(bs);

        [MethodImpl(Inline)]
        public static BitString And(this BitString xbs, BitString ybs)
            => api.and(xbs,ybs);

        [MethodImpl(Inline)]
        public static BitString Or(this BitString xbs, BitString ybs)
            => api.or(xbs,ybs);

        [MethodImpl(Inline)]
        public static BitString Xor(this BitString xbs, BitString ybs)
            => api.xor(xbs,ybs);

        [MethodImpl(Inline)]
        public static BitString Srl(this BitString bs, int shift)
            => api.srl(bs,shift);

        [MethodImpl(Inline)]
        public static BitString Sll(this BitString bs, int shift)
            => api.sll(bs,shift);

        /// <summary>
        /// Rotates the bits leftwards by a specified offset
        /// </summary>
        /// <param name="offset">The magnitude of the rotation</param>
        public static BitString RotL(this BitString bs, uint offset)
            => api.rotl(bs, offset);
    }
}