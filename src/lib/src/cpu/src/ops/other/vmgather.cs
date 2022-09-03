//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Avx2;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// __m256i _mm256_i32gather_epi32 (int const* base_addr, __m256i vindex, const int scale) VPGATHERDD ymm, vm32y, ymm
        /// </summary>
        /// <param name="src"></param>
        /// <param name="vidx"></param>
        /// <param name="scale"></param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vmgather(MemoryAddress @base, Vector256<uint> vidx, [Imm] ScaleFactor scale)
            => GatherVector256(@base.Pointer<uint>(), v32i(vidx), (byte)scale);

        /// <summary>
        /// __m128i _mm_mask_i32gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale) VPGATHERDD xmm, vm32x, xmm
        /// </summary>
        /// <param name="base">The memory-based source for target component data as controlled by the mask vector</param>
        /// <param name="vsrc">The vector-based source for target component data as controlled by the mask vector</param>
        /// <param name="vidx">The index vector</param>
        /// <param name="mask">The vector that determines whether target vector components are loaded from the vector or memory source</param>
        /// <remarks>Elements are copied from the source vector when the highest bit of the corresponding element in the mask vector is not set
        /// If, for example, all hi bits in the mask vector are set then the corresponding target element is loaded from the index-identified cell
        /// and this operation reduces to the coresponding maskless gather function
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<uint> vmgather(MemoryAddress @base, Vector128<uint> vsrc, Vector128<int> vidx, Vector128<uint> mask)
            => GatherMaskVector128(vsrc, @base.Pointer<uint>(), vidx, mask, 4);

        /// <summary>
        /// __m128i _mm_mask_i64gather_epi64 (__m128i src, __int64 const* base_addr, __m128i vindex, __m128i mask, const int scale) VPGATHERQQ xmm, vm64x, xmm
        /// </summary>
        /// <param name="vsrc">The vector-based source for target component data as controlled by the mask vector</param>
        /// <param name="msrc">The memory-based source for target component data as controlled by the mask vector</param>
        /// <param name="vidx">The index vector</param>
        /// <param name="mask">The vector that determines whether target vector components are loaded from the vector or memory source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<ulong> vmgather(Vector128<ulong> vsrc, MemoryAddress msrc, Vector128<long> vidx, Vector128<ulong> mask)
            => GatherMaskVector128(vsrc, msrc.Pointer<ulong>(), vidx, mask, 8);

        /// <summary>
        /// __m128i _mm_mask_i32gather_epi64 (__m128i src, __int64 const* base_addr, __m128i vindex, __m128i mask, const int scale) VPGATHERDQ xmm, vm32x, xmm
        /// </summary>
        /// <param name="vsrc">The vector-based source for target component data as controlled by the mask vector</param>
        /// <param name="msrc">The memory-based source for target component data as controlled by the mask vector</param>
        /// <param name="vidx">The index vector</param>
        /// <param name="mask">The vector that determines whether target vector components are loaded from the vector or memory source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<ulong> vmgather(Vector128<ulong> vsrc, MemoryAddress msrc, Vector128<int> vidx, Vector128<ulong> mask)
            => GatherMaskVector128(vsrc, msrc.Pointer<ulong>(), vidx, mask, 8);

        /// <summary>
        /// __m128i _mm_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale) VPGATHERQD xmm, vm64x, xmm
        /// </summary>
        /// <param name="vsrc">The vector-based source for target component data as controlled by the mask vector</param>
        /// <param name="msrc">The memory-based source for target component data as controlled by the mask vector</param>
        /// <param name="vidx">The index vector</param>
        /// <param name="mask">The vector that determines whether target vector components are loaded from the vector or memory source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<uint> vmgather(Vector128<uint> vsrc, MemoryAddress msrc, Vector128<long> vidx, Vector128<uint> mask)
            => GatherMaskVector128(vsrc, msrc.Pointer<uint>(), vidx, mask, 4);

        /// <summary>
        /// __m128i _mm256_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m256i vindex, __m128i mask, const int scale) VPGATHERQD xmm, vm32y, xmm
        /// </summary>
        /// <param name="vsrc">The vector-based source for target component data as controlled by the mask vector</param>
        /// <param name="msrc">The memory-based source for target component data as controlled by the mask vector</param>
        /// <param name="mSrc">The memory-based source for target component data as controlled by the mask vector</param>
        /// <param name="vidx">The index vector</param>
        /// <param name="mask">The vector that determines whether target vector components are loaded from the vector or memory source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<uint> vmgather(Vector128<uint> vsrc,  MemoryAddress msrc, Vector256<long> vidx, Vector128<uint> mask)
            => GatherMaskVector128(vsrc, msrc.Pointer<uint>(), vidx, mask, 4);

        /// <summary>
        ///   __m256i _mm256_mask_i32gather_epi32 (__m256i src, int const* base_addr, __m256i vindex, __m256i mask, const int scale) VPGATHERDD ymm, vm32y, ymm
        /// </summary>
        /// <param name="vsrc">The vector-based source for target component data as controlled by the mask vector</param>
        /// <param name="msrc">The memory-based source for target component data as controlled by the mask vector</param>
        /// <param name="vidx">The index vector</param>
        /// <param name="mask">The vector that determines whether target vector components are loaded from the vector or memory source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vmgather(Vector256<uint> vsrc, MemoryAddress msrc, Vector256<int> vidx, Vector256<uint> mask)
            => GatherMaskVector256(vsrc, msrc.Pointer<uint>(), vidx, mask, 4);

        /// <summary>
        /// __m256i _mm256_mask_i64gather_epi64 (__m256i src, __int64 const* base_addr, __m256i vindex, __m256i mask, const int scale) VPGATHERQQ ymm, vm32y, ymm
        /// </summary>
        /// <param name="vsrc">The vector-based source for target component data as controlled by the mask vector</param>
        /// <param name="msrc">The memory-based source for target component data as controlled by the mask vector</param>
        /// <param name="vidx">The index vector</param>
        /// <param name="mask">The vector that determines whether target vector components are loaded from the vector or memory source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vmgather(Vector256<ulong> vsrc, MemoryAddress msrc, Vector256<long> vidx, Vector256<ulong> mask)
            => GatherMaskVector256(vsrc, msrc.Pointer<ulong>(), vidx, mask, 8);

        /// <summary>
        ///  __m256i _mm256_mask_i32gather_epi64 (__m256i src, __int64 const* base_addr, __m128i vindex, __m256i mask, const int scale) VPGATHERDQ ymm, vm32y, ymm
        /// </summary>
        /// <param name="vsrc">The vector-based source for target component data as controlled by the mask vector</param>
        /// <param name="msrc">The memory-based source for target component data as controlled by the mask vector</param>
        /// <param name="vidx">The index vector</param>
        /// <param name="mask">The vector that determines whether target vector components are loaded from the vector or memory source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vmgather(Vector256<ulong> vsrc, MemoryAddress msrc, Vector128<int> vidx, Vector256<ulong> mask)
            => GatherMaskVector256(vsrc, msrc.Pointer<ulong>(), vidx, mask, 8);
    }
}