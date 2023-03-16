//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class vbits
    {
        // [MethodImpl(Inline), Op]
        // public static BitVector128<ulong> load(W128 w, ulong a, ulong b)
        //     => vparts(w,a,b);

        // [MethodImpl(Inline), Op]
        // public static BitVector128<uint> load(W128 w, uint a0, uint a1, uint a2, uint a3)
        //     => vparts(w,a0,a1,a2,a3);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static BitVector128<T> load<T>(W128 w, ReadOnlySpan<T> src)
        //     where T : unmanaged
        //         => vgcpu.vload(w,src);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static BitVector256<T> load<T>(W256 w, ReadOnlySpan<T> src)
        //     where T : unmanaged
        //         => vgcpu.vload(w,src);        

        /// <summary>
        /// Populates a bitstring from a 128-bit cpu vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="maxbits">The maximum number of bits to extract from the source</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<T>(Vector128<T> src, int? maxbits = null)
            where T : unmanaged
                => BitStrings.scalars(sys.cover(vcpu.vref(ref src), vcpu.vcount<T>(W128.W)), maxbits);

        /// <summary>
        /// Populates a bitstring from a 256-bit cpu vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="maxbits">The maximum number of bits to extract</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<T>(Vector256<T> src, int? maxbits = null)
            where T : unmanaged
                => BitStrings.scalars(sys.cover(vcpu.vref(ref src), vcpu.vcount<T>(W256.W)), maxbits);

        /// <summary>
        /// Populates a bitstring from a 256-bit cpu vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="maxbits">The maximum number of bits to extract</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<T>(Vector512<T> src, int? maxbits = null)
            where T : unmanaged
                => BitStrings.scalars(sys.cover(vcpu.vref(ref src), vcpu.vcount<T>(W512.W)), maxbits);
    }

    partial class XTend
    {
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
        /// Converts an 128-bit intrinsic vector representation to a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this Vector128<T> src, int? maxbits = null)
            where T : unmanaged
                => vbits.bitstring(src, maxbits);

        /// <summary>
        /// Converts an 256-bit vector representation to a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this Vector256<T> src, int? maxbits = null)
            where T : unmanaged
                => vbits.bitstring(src, maxbits);

        /// <summary>
        /// Converts a 512-bit vector representation to a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this Vector512<T> src, int? maxbits = null)
            where T : unmanaged
                => vbits.bitstring(src, maxbits);

    }
}