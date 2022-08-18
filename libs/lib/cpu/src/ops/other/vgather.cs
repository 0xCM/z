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
    using static core;

    partial struct cpu
    {
        /// <summary>
        /// __m256i _mm256_i32gather_epi32 (int const* base_addr, __m256i vindex, const int scale) VPGATHERDD ymm, vm32y, ymm
        /// Loads 8 unsigned 32-bit integers from base-relative locations, unscaled
        /// </summary>
        /// <param name="base">The base address from which the load is relative</param>
        /// <param name="vidx">The base-relative addresses of the 8 values to load</param>
        /// <param name="scale">The scale selector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vgather(MemoryAddress @base, Vector256<uint> vidx)
            => GatherVector256(@base.Pointer<uint>(), v32i(vidx), 1);

        /// <summary>
        /// __m256i _mm256_i32gather_epi32 (int const* base_addr, __m256i vindex, const int scale) VPGATHERDD ymm, vm32y, ymm
        /// Loads 8 unsigned 32-bit integers from base-relative locations with a scale factor of 2
        /// </summary>
        /// <param name="base">The base address from which the load is relative</param>
        /// <param name="vidx">The base-relative addresses of the 8 values to load</param>
        /// <param name="scale">The scale selector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vgather(MemoryAddress @base, Vector256<uint> vidx, N2 scale)
            => GatherVector256(@base.Pointer<uint>(), v32i(vidx), 2);

        /// <summary>
        /// __m256i _mm256_i32gather_epi32 (int const* base_addr, __m256i vindex, const int scale) VPGATHERDD ymm, vm32y, ymm
        /// Loads 8 unsigned 32-bit integers from base-relative locations with a scale factor of 4
        /// </summary>
        /// <param name="base">The base address from which the load is relative</param>
        /// <param name="vidx">The base-relative addresses of the 8 values to load</param>
        /// <param name="scale">The scale selector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vgather(MemoryAddress @base, Vector256<uint> vidx, N4 scale)
            => GatherVector256(@base.Pointer<uint>(), v32i(vidx), 4);

        /// <summary>
        /// __m256i _mm256_i32gather_epi32 (int const* base_addr, __m256i vindex, const int scale) VPGATHERDD ymm, vm32y, ymm
        /// Loads 8 unsigned 32-bit integers from base-relative locations with a scale factor of 8
        /// </summary>
        /// <param name="base">The base address from which the load is relative</param>
        /// <param name="vidx">The base-relative addresses of the 8 values to load</param>
        /// <param name="scale">The scale selector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vgather(MemoryAddress @base, Vector256<uint> vidx, N8 scale)
            => GatherVector256(@base.Pointer<uint>(), v32i(vidx), 8);

        /// <summary>
        ///  __m128i _mm_i32gather_epi32 (int const* base_addr, __m128i vindex, const int scale) VPGATHERDD xmm, vm32x, xmm
        /// Loads a 128x32i vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<int> vgather(N128 w, in int src, Vector128<int> index)
            => GatherVector128(gptr(src), index, 4);

        /// <summary>
        /// __m128i _mm256_i64gather_epi32 (int const* base_addr, __m256i vindex, const int scale) VPGATHERQD xmm, vm64y, xmm
        /// Loads a 128x32u vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<uint> vgather(N128 w, in uint src, Vector256<ulong> vidx)
            => GatherVector128(gptr(src), v64i(vidx), 4);

        /// <summary>
        /// __m128i _mm_i64gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale) VPGATHERQQ xmm, vm64x, xmm
        /// Loads a 128x64u vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<long> vgather(N128 w, in long src, Vector128<long> vidx)
            => GatherVector128(gptr(src), vidx, 8);

        /// <summary>
        /// __m128i _mm_i64gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale) VPGATHERQQ xmm, vm64x, xmm
        /// Loads a 128x32u vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<ulong> vgather(N128 w, in ulong src, Vector128<ulong> vidx)
            => GatherVector128(gptr(src), v64i(vidx), 8);

        /// <summary>
        /// __m256i _mm256_i32gather_epi32 (int const* base_addr, __m256i vindex, const int scale) VPGATHERDD ymm, vm32y, ymm
        /// Loads a 256x32i vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<int> vgather(N256 w, in int src, Vector256<int> index)
            => GatherVector256(gptr(src), index, 4);

        /// <summary>
        /// __m128i _mm_i32gather_epi32(int const* base_addr, __m128i vindex, const int scale) VPGATHERDD xmm, vm32x, xmm
        /// Loads a 128x32u vector from from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<uint> vgather(N128 w, in uint src, Vector128<uint> vidx)
            => GatherVector128(gptr(src), v32i(vidx), 4);

        /// <summary>
        /// __m256i _mm256_i32gather_epi32 (int const* base_addr, __m256i vindex, const int scale) VPGATHERDD ymm, vm32y, ymm
        /// Loads a 256x32u vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vgather(N256 w, in uint src, Vector256<uint> vidx)
            => GatherVector256(gptr(src), v32i(vidx), 4);

        /// <summary>
        /// __m256i _mm256_i64gather_epi64 (__int64 const* base_addr, __m256i vindex, const int scale) VPGATHERQQ ymm, vm64y, ymm
        /// Loads a 256x64i vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<long> vgather(N256 w, in long src, Vector256<long> index)
            => GatherVector256(gptr(src), index, 8);

        /// <summary>
        /// __m256i _mm256_i64gather_epi64 (__int64 const* base_addr, __m256i vindex, const int scale) VPGATHERQQ ymm, vm64y, ymm
        /// Loads a 256x64u vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vgather(N256 w, in ulong src, Vector256<ulong> vidx)
            => GatherVector256(gptr(src), v64i(vidx), 8);

        /// <summary>
        /// __m256i _mm256_i32gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale) VPGATHERDQ ymm, vm32y, ymm
        /// Loads a 256x64u vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vgather(N256 w, in ulong src, Vector128<uint> vidx)
            => GatherVector256(gptr(src), v32i(vidx), 8);

        /// <summary>
        /// Loads a 128x16u vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<ushort> vgather(N128 w, in ushort src, Vector128<ushort> vidx)
            => vpack.vpack128x16u(GatherVector256(p32u(src), v32i(vpack.vinflate256x32u(vidx)), 2));

        /// <summary>
        /// Loads a 128x16i vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<short> vgather(N128 w, in short src, Vector128<short> vidx)
            => v16i(vpack.vpack128x16u(GatherVector256(p32u(src), v32i(vpack.vinflate256x32u(v16u(vidx))),2)));

        /// <summary>
        /// Loads a 128x8u vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<sbyte> vgather(N128 w, in sbyte src, Vector128<sbyte> vidx)
        {
            (var v0, var v1) = vpack.vinflate512x32u(v8u(vidx));
            var x0 = GatherVector256(p32u(src), v32i(v0),1);
            var x1 = GatherVector256(p32u(src), v32i(v1),1);
            return v8i(vpack.vpack128x8u(x0, x1));
        }

        /// <summary>
        /// Loads a 128x8u vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<byte> vgather(N128 w, in byte src, Vector128<byte> vidx)
        {
            (var v0, var v1) = vpack.vinflate512x32u(vidx);
            var x0 = GatherVector256(p32u(src), v32i(v0), 1);
            var x1 = GatherVector256(p32u(src), v32i(v1), 1);
            return vpack.vpack128x8u(x0, x1);
        }

        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vgather(N256 w, in sbyte src, Vector256<sbyte> vidx)
            => vconcat(vgather(n128, src, vlo(vidx)), vgather(n128, src, vhi(vidx)));

        [MethodImpl(Inline), Op]
        public static Vector256<byte> vgather(N256 w, in byte src, Vector256<byte> vidx)
            => vconcat(vgather(n128, src, vlo(vidx)), vgather(n128, src, vhi(vidx)));

        [MethodImpl(Inline), Op]
        public static Vector256<short> vgather(N256 w, in short src, Vector256<short> vidx)
            => vconcat(vgather(n128, src, vlo(vidx)), vgather(n128, src, vhi(vidx)));

        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vgather(N256 w, in ushort src, Vector256<ushort> vidx)
            => vconcat(vgather(n128, src, vlo(vidx)), vgather(n128, src, vhi(vidx)));

        /// <summary>
        ///  __m256i _mm256_i64gather_epi64 (__int64 const* base_addr, __m256i vindex, const int scale) VPGATHERQQ ymm, vm64y, ymm
        /// Loads a 256x64i vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        /// <param name="scale">The amount by which to scale each index component value</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<long> vgather(in long src, Vector256<long> vidx, [Imm] ScaleFactor scale)
            => GatherVector256(gptr(src), vidx, (byte)scale);

        /// <summary>
        /// __m256i _mm256_i64gather_epi64 (__int64 const* base_addr, __m256i vindex, const int scale) VPGATHERQQ ymm, vm64y, ymm
        /// Loads a 256x64u vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        /// <param name="scale">The amount by which to scale each index component value</param>
        /// <remarks>Intel's description:
        /// Gather 64-bit integers from memory using 64-bit indices. 64-bit elements are loaded from addresses
        /// starting at base_addr and offset by each 64-bit element in vindex (each index is scaled by the factor in scale).
        /// Gathered elements are merged into dst. scale should be 1, 2, 4 or 8.
        /// FOR j := 0 to 3, i := j*64, m := j*64
        ///	    dst[i+63:i] := MEM[base_addr + SignExtend(vindex[m+63:m])*scale]
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vgather(in ulong src, Vector256<long> vidx, [Imm] ScaleFactor scale)
            => GatherVector256(gptr(src), vidx, (byte)scale);

        /// <summary>
        /// __m256i _mm256_i32gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale) VPGATHERDQ ymm, vm32y, ymm
        /// Loads a 256x64u vector from index-identified source cells
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory source</param>
        /// <param name="vidx">The index vector</param>
        /// <param name="scale">The amount by which to scale each index component value</param>
        /// <remarks>Intel's description:
        /// Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses
        /// starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale).
        /// Gathered elements are merged into dst. scale should be 1, 2, 4 or 8.
        /// FOR j := 0 to 3, i := j*64, m := j*32
	    ///     dst[i+63:i] := MEM[base_addr + SignExtend(vindex[m+31:m])*scale]
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vgather(in ulong src, Vector128<int> vidx, [Imm] ScaleFactor scale)
            => GatherVector256(gptr(src), vidx, (byte)scale);
    }
}