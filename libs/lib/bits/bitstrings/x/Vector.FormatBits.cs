//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
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
        /// Formats vector bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
        public static string FormatBits<T>(this Vector128<T> src, int? maxbits = null,  bool tlz = false, bool specifier = false, int? blockWidth = null,
            char? blocksep = null, int? rowWidth = null)
                where T : unmanaged
                    => src.ToBitString(maxbits).Format(BitFormat.define(tlz, specifier, blockWidth, blocksep, rowWidth,null));

        /// <summary>
        /// Formats vector bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
        public static string FormatBits<T>(this Vector256<T> src, int? maxbits = null, bool tlz = false, bool specifier = false, int? blockWidth = null,
            char? blocksep = null, int? rowWidth = null)
                where T : unmanaged
                    =>  src.ToBitString(maxbits).Format(BitFormat.define(tlz, specifier, blockWidth, blocksep, rowWidth,null));
    }
}