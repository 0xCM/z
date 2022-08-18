//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Sse41.X64;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_insert_epi8 (__m128i a, int i, const int imm8) PINSRB xmm, reg/m8, imm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vinsert(byte src, Vector128<byte> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        ///  __m128i _mm_insert_epi8 (__m128i a, int i, const int imm8) PINSRB xmm, reg/m8, imm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vinsert(sbyte src, Vector128<sbyte> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        /// __m128i _mm_insert_epi16 (__m128i a, int i, int immediate) PINSRW xmm, reg/m16, imm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vinsert(short src, Vector128<short> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        /// __m128i _mm_insert_epi16 (__m128i a, int i, int immediate) PINSRW xmm, reg/m16, imm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vinsert(ushort src, Vector128<ushort> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        /// __m128i _mm_insert_epi32 (__m128i a, int i, const int imm8) PINSRD xmm, reg/m32, xmm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vinsert(int src, Vector128<int> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        /// __m128i _mm_insert_epi32 (__m128i a, int i, const int imm8) PINSRD xmm, reg/m32, xmm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vinsert(uint src, Vector128<uint> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        /// __m128i _mm_insert_epi64 (__m128i a, __int64 i, const int imm8) PINSRQ xmm, reg/m64,imm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vinsert(long src, Vector128<long> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        /// __m128i _mm_insert_epi64 (__m128i a, __int64 i, const int imm8) PINSRQ xmm, reg/m64, imm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vinsert(ulong src, Vector128<ulong> dst, [Imm] byte index)
            => Insert(dst, src, index);
    }
}