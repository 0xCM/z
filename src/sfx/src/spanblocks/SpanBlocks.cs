//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static sys;
    using static vcpu;

    [ApiHost]
    public readonly partial struct SpanBlocks
    {

        /// <summary>
        /// Effects a component-wise contraction on the source vector on a source vector of unsigned primal type,
        /// dst[i] = src[i].Contract(max[i])
        /// </summary>
        /// <param name="src">The vector to contract</param>
        /// <param name="max">The upper bound</param>
        /// <typeparam name="N">The length type</typeparam>
        /// <typeparam name="T">The unsigned primal type</typeparam>
        public static Block256<N,T> contract<N,T>(Block256<N,T> src, Block256<N,T> max)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var dst = NatSpans.alloc<N,T>();
            for(var i=0; i<dst.Count; i++)
                dst[i] = gcalc.squeeze(src[i],max[i]);
            return dst;
        }

        /// <summary>
        /// Effects a component-wise contraction on the source vector on a source vector of unsigned primal type,
        /// dst[i] = src[i].Contract(max[i])
        /// </summary>
        /// <param name="src">The vector to contract</param>
        /// <param name="max">The upper bound</param>
        /// <typeparam name="N">The length type</typeparam>
        /// <typeparam name="T">The unsigned primal type</typeparam>
        public static RowVector256<T> contract<T>(RowVector256<T> src, RowVector256<T> max)
            where T : unmanaged
        {
            var len = src.Length;
            var dst = Z0.RowVectors.blockalloc<T>(len);
            for(var i=0; i<dst.Length; i++)
                dst[i] = gcalc.squeeze(src[i], max[i]);
            return dst;
        }

        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static void aesEncode(SpanBlock128<byte> src, Vector128<byte> key, SpanBlock128<byte> dst)
        {
            for(var block = 0; block < src.BlockCount; block++)
                 vcpu.vstore(vcpu.aesEncode(src.LoadVector(block),key), ref dst.BlockLead(block));
        }

        [MethodImpl(Inline), Op]
        public static void aesdec(SpanBlock128<byte> src, Vector128<byte> key, SpanBlock128<byte> dst)
        {
            for(var block = 0; block < src.BlockCount; block++)
                 vcpu.vstore(vcpu.aesDecode(src.LoadVector(block),key), ref dst.BlockLead(block));
        }

        /// <summary>
        /// Loads a 128-bit vector from the first 128-bit source block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vload<T>(SpanBlock128<T> src)
            where T : unmanaged
                => vgcpu.vload(w128, src.Storage);

        /// <summary>
        /// Loads a 256-bit vector from the leading source block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vload<T>(SpanBlock256<T> src)
            where T : unmanaged
                => vgcpu.vload(w256, src.Storage);

        /// <summary>
        /// Loads a 512-bit vector from the leading source block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vload<T>(in SpanBlock512<T> src)
            where T : unmanaged
                => vgcpu.vload(w512, src.Storage);

        /// <summary>
        /// Loads a block-identified 128-bit vector
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vload<T>(SpanBlock128<T> src, int block)
            where T : unmanaged
                => vgcpu.vload(src.BlockLead(block), out Vector128<T> x);

        /// <summary>
        /// Loads a block-identified 256-bit vector
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vload<T>(SpanBlock256<T> src, int block)
            where T : unmanaged
                => vgcpu.vload(src.BlockLead(block), out Vector256<T> x);

        /// <summary>
        /// Loads a block-identified 512-bit vector
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vload<T>(in SpanBlock512<T> src, int block)
            where T : unmanaged
                => vgcpu.vload(src.BlockLead(block), out Vector512<T> x);

        /// <summary>
        /// Stores the source vector to the head of a blocked container
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void vstore<T>(Vector128<T> src, SpanBlock128<T> dst)
            where T : unmanaged
                => vgcpu.vstore(src, ref dst.First);

        /// <summary>
        /// Stores the source vector to a specified block in a blocked container
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The 0-based block index at which storage should begin</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void vstore<T>(Vector128<T> src, SpanBlock128<T> dst, int block)
            where T : unmanaged
                => vgcpu.vstore(src, ref dst.BlockLead(block));

        /// <summary>
        /// Stores the source vector to a blocked container
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void vstore<T>(Vector256<T> src, SpanBlock256<T> dst)
            where T : unmanaged
                => vgcpu.vstore(src, ref dst.First);


        /// <summary>
        /// Stores the source vector to a specified block in a blocked container
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The 0-based block index at which storage should begin</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void vstore<T>(Vector256<T> src, SpanBlock256<T> dst, int block)
            where T : unmanaged
                => vgcpu.vstore(src, ref dst.BlockLead(block));


        /// <summary>
        /// __m128i _mm_maskload_epi32 (int const* mem_addr, __m128i mask) VPMASKMOVD xmm, xmm, m128
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<int> vmaskload(SpanBlock128<int> src, uint block, Vector128<int> mask)
            => MaskLoad(gptr(src.BlockLead(block)), mask);

        /// <summary>
        /// __m128i _mm_maskload_epi32 (int const* mem_addr, __m128i mask) VPMASKMOVD xmm, xmm, m128
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<uint> vmaskload(SpanBlock128<uint> src, uint block, Vector128<uint> mask)
            => MaskLoad(gptr(src.BlockLead(block)), mask);

        /// <summary>
        /// __m256i _mm256_maskload_epi32 (int const* mem_addr, __m256i mask) VPMASKMOVD ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<int> vmaskload(SpanBlock256<int> src, uint block, Vector256<int> mask)
            => MaskLoad(gptr(src.BlockLead(block)), mask);

        /// <summary>
        /// Conditionally loads source cells per a specified mask
        /// __m256i _mm256_maskload_epi32 (int const* mem_addr, __m256i mask) VPMASKMOVD ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vmaskload(SpanBlock256<uint> src, uint block, Vector256<uint> mask)
            => MaskLoad(gptr(src.BlockLead(block)), mask);

        /// <summary>
        /// __m256i _mm256_maskload_epi64 (__int64 const* mem_addr, __m256i mask) VPMASKMOVQ ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<long> vmaskload(SpanBlock256<long> src, uint block, Vector256<long> mask)
            => MaskLoad(gptr(src.BlockLead(block)), mask);

        /// <summary>
        /// __m256i _mm256_maskload_epi64 (__int64 const* mem_addr, __m256i mask) VPMASKMOVQ ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vmaskload(SpanBlock256<ulong> src, uint block, Vector256<ulong> mask)
            => MaskLoad(gptr(src.BlockLead(block)), mask);

 
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
        
        /// <summary>
        /// VPMOVZXDQ ymm, m128
        /// 8x32u -> 8x64u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="lo">The lower target</param>
        /// <param name="hi">The upper target</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector512<ulong> vinflate512x64u(SpanBlock256<uint> src, uint offset)
            => Vector512.Create(v64u(ConvertToVector256Int64(gptr(src[offset]))),
                v64u(ConvertToVector256Int64(gptr(src[offset],4))));

        /// <summary>
        /// VPMOVZXWQ ymm, m64
        /// 8x16u -> 8x64u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="lo">The lower target</param>
        /// <param name="hi">The upper target</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector512<ulong> vinflate512x64u(SpanBlock128<ushort> src, uint offset)
            => Vector512.Create(v64u(ConvertToVector256Int64(gptr(src[offset]))),
                v64u(ConvertToVector256Int64(gptr(src[offset],4))));

        /// <summary>
        /// VPMOVZXWD ymm, m128
        /// 16x16u ->16x32u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector512<uint> vinflate512x32u(SpanBlock256<ushort> src, uint offset)
            => Vector512.Create(v32u(ConvertToVector256Int32(gptr(src[offset]))),
                v32u(ConvertToVector256Int32(gptr(src[offset], 8))));

        /// <summary>
        /// VPMOVZXBQ ymm, m32
        /// 4x8u -> 4x64u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vinflate256x64u(in SpanBlock32<byte> src, uint offset)
            => v64u(ConvertToVector256Int64(gptr(src[offset])));

        /// <summary>
        /// VPMOVZXWQ ymm, m64
        /// 4x16u -> 4x64u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vinflate256x64u(in SpanBlock64<ushort> src, uint offset)
            => v64u(ConvertToVector256Int64(gptr(src[offset])));

        /// <summary>
        /// VPMOVZXDQ ymm, m128
        /// 4x32u -> 4x64u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vinflate256x64u(SpanBlock128<uint> src, uint offset)
            => v64u(ConvertToVector256Int64(gptr(src[offset])));


        /// <summary>
        /// VPMOVSXWD ymm, m128
        /// 16x16u ->16x32u
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector512<int> vinflate512x32i(SpanBlock128<short> src, uint offset)
            => Vector512.Create(ConvertToVector256Int32(gptr(src[offset])),
                ConvertToVector256Int32(gptr(src[offset], 8)));

        /// <summary>
        /// Returns true if all source blocks satisfy a specified unary predicate
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="f">The reified predicate</param>
        /// <typeparam name="F">The predicate reification type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit all<F,T>(SpanBlock128<T> src, F f)
            where T : unmanaged
            where F : IUnaryPred128<T>
        {
            var blocks = src.BlockCount;
            var result = bit.On;
            for(var block = 0; block<blocks; block++)
                result &= f.Invoke(src.LoadVector(block));
            return result;
        }

        /// <summary>
        /// Returns true if all source blocks satisfy a specified unary predicate
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="f">The reified predicate</param>
        /// <typeparam name="F">The predicate reification type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit all<F,T>(SpanBlock256<T> src, F f)
            where T : unmanaged
            where F : IUnaryPred256<T>
        {
            var blocks = src.BlockCount;
            var result = bit.On;
            for(var block=0; block<blocks; block++)
                result &= f.Invoke(src.LoadVector(block));
            return result;
        }

        [MethodImpl(Inline)]
        public static bit all<F,T>(SpanBlock128<T> a, SpanBlock128<T> b, F f)
            where T : unmanaged
            where F : IBinaryPred128<T>
        {
            var blocks = a.BlockCount;
            var result = bit.On;
            for(var block = 0; block<blocks; block++)
                result &= f.Invoke(a.LoadVector(block), b.LoadVector(block));
            return result;
        }

        [MethodImpl(Inline)]
        public static bit all<F,T>(SpanBlock256<T> a, SpanBlock256<T> b, F f)
            where T : unmanaged
            where F : IBinaryPred256<T>
        {
            var blocks = a.BlockCount;
            var result = bit.On;
            for(var block = 0; block<blocks; block++)
                result &= f.Invoke(a.LoadVector(block), b.LoadVector(block));
            return result;
        }
 
        [MethodImpl(Inline)]
        public static SpanBlock128<T> map<F,T>(SpanBlock128<T> src, SpanBlock128<T> dst, F f)
            where T : unmanaged
            where F : IUnaryOp128<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block < blocks; block++)
                f.Invoke(src.LoadVector(block)).StoreTo(dst, block);
            return dst;
        }

        [MethodImpl(Inline)]
        public static SpanBlock256<T> map<F,T>(SpanBlock256<T> src, SpanBlock256<T> dst, F f)
            where T : unmanaged
            where F : IUnaryOp256<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(src.LoadVector(block)).StoreTo(dst, block);
            return dst;
        }

        [MethodImpl(Inline)]
        public static Span<bit> map<F,T>(SpanBlock128<T> src, Span<bit> dst, F f)
            where T : unmanaged
            where F : IUnaryPred128<T>
        {
            var blocks = src.BlockCount;
            ref var result = ref first(dst);
            for(var block = 0; block < blocks; block++)
                seek(result, block) = f.Invoke(src.LoadVector(block));
            return dst;
        }

        [MethodImpl(Inline)]
        public static Span<bit> map<F,T>(SpanBlock256<T> src, Span<bit> dst, F f)
            where T : unmanaged
            where F : IUnaryPred256<T>
        {
            var blocks = src.BlockCount;
            ref var result = ref first(dst);
            for(var block = 0; block<blocks; block++)
                seek(result, block) = f.Invoke(src.LoadVector(block));
            return dst;
        }

        [MethodImpl(Inline)]
        public static SpanBlock16<T> zip<F,T>(SpanBlock16<T> a, SpanBlock16<T> b, SpanBlock16<T> dst, F f)
            where T : unmanaged
            where F : IBinarySpanOp<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(a.CellBlock(block), b.CellBlock(block), dst);
            return dst;
        }

        [MethodImpl(Inline)]
        public static SpanBlock32<T> zip<F,T>(SpanBlock32<T> a, SpanBlock32<T> b, SpanBlock32<T> dst, F f)
            where T : unmanaged
            where F : IBinarySpanOp<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(a.CellBlock(block), b.CellBlock(block), dst);
            return dst;
        }

        [MethodImpl(Inline)]
        public static SpanBlock64<T> zip<F,T>(SpanBlock64<T> a, SpanBlock64<T> b, SpanBlock64<T> dst, F f)
            where T : unmanaged
            where F : IBinarySpanOp<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(a.CellBlock(block), b.CellBlock(block), dst);
            return dst;
        }

        [MethodImpl(Inline)]
        public static SpanBlock128<T> zip<F,T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst, F f)
            where T : unmanaged
            where F : IBinaryOp128<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(a.LoadVector(block), b.LoadVector(block)).StoreTo(dst, block);
            return dst;
        }

        [MethodImpl(Inline)]
        public static SpanBlock256<T> zip<F,T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst, F f)
            where T : unmanaged
            where F : IBinaryOp256<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(a.LoadVector(block), b.LoadVector(block)).StoreTo(dst, block);
            return dst;
        }

        [MethodImpl(Inline)]
        public static SpanBlock128<T> zip<F,T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> c, SpanBlock128<T> dst, F f)
            where T : unmanaged
            where F : ITernaryOp128<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(a.LoadVector(block), b.LoadVector(block), c.LoadVector(block)).StoreTo(dst, block);
            return dst;
        }

        [MethodImpl(Inline)]
        public static SpanBlock256<T> zip<F,T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> c, SpanBlock256<T> dst, F f)
            where T : unmanaged
            where F : ITernaryOp256<T>
        {
            var blocks = dst.BlockCount;
            for(var block=0; block<blocks; block++)
                f.Invoke(a.LoadVector(block), b.LoadVector(block), c.LoadVector(block)).StoreTo(dst, block);
            return dst;
        }

        [MethodImpl(Inline)]
        public static SpanBlock128<T> zip<F,T>(SpanBlock128<T> src, byte imm8, SpanBlock128<T> dst, F f)
            where T : unmanaged
            where F : IShiftOp128<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block < blocks; block++)
                f.Invoke(src.LoadVector(block),imm8).StoreTo(dst, block);
            return dst;
        }

        [MethodImpl(Inline)]
        public static SpanBlock256<T> zip<F,T>(SpanBlock256<T> src, byte imm8, SpanBlock256<T> dst, F f)
            where T : unmanaged
            where F : IShiftOp256<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block < blocks; block++)
                f.Invoke(src.LoadVector(block),imm8).StoreTo(dst, block);
            return dst;
        }

        [MethodImpl(Inline)]
        public static Span<bit> zip<F,T>(SpanBlock128<T> a, SpanBlock128<T> b, Span<bit> dst, F f)
            where T : unmanaged
            where F : IBinaryPred128<T>
        {
            var blocks = a.BlockCount;
            ref var result = ref first(dst);
            for(var block = 0; block<blocks; block++)
                seek(result, block) = f.Invoke(a.LoadVector(block), b.LoadVector(block));
            return dst;
        }

        [MethodImpl(Inline)]
        public static Span<bit> zip<F,T>(SpanBlock256<T> a, SpanBlock256<T> b, Span<bit> dst, F f)
            where T : unmanaged
            where F : IBinaryPred256<T>
        {
            var blocks = a.BlockCount;
            ref var result = ref first(dst);
            for(var block = 0; block<blocks; block++)
                seek(result, block) = f.Invoke(a.LoadVector(block), b.LoadVector(block));
            return dst;
        }

        [Free]
        public delegate SpanBlock8<T> UnarySpanOp8<T>(SpanBlock8<T> src, SpanBlock8<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock16<T> UnarySpanOp16<T>(SpanBlock16<T> src, SpanBlock16<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock32<T> UnarySpanOp32<T>(SpanBlock32<T> src, SpanBlock32<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock64<T> UnarySpanOp64<T>(SpanBlock64<T> src, SpanBlock64<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock256<T> UnarySpanOp256<T>(SpanBlock256<T> src, SpanBlock256<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock128<T> UnarySpanOp128<T>(SpanBlock128<T> src, SpanBlock128<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock512<T> UnarySpanOp512<T>(SpanBlock512<T> src, SpanBlock512<T> dst)
            where T : unmanaged;
        [Free]
        public delegate SpanBlock8<T> BinaryOp8<T>(SpanBlock8<T> a, SpanBlock8<T> b, SpanBlock8<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock16<T> BinaryOp16<T>(SpanBlock16<T> a, SpanBlock16<T> b, SpanBlock16<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock32<T> BinaryOp32<T>(SpanBlock32<T> a, SpanBlock32<T> b, SpanBlock32<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock64<T> BinaryOp64<T>(SpanBlock64<T> a, SpanBlock64<T> b, SpanBlock64<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock128<T> BinaryOp128<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock256<T> BinaryOp256<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock512<T> BinaryOp512<T>(SpanBlock512<T> a, SpanBlock512<T> b, SpanBlock512<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock128<T> UnaryOp128Imm8<T>(SpanBlock128<T> src, byte imm8, SpanBlock128<T> dst)
            where T : unmanaged;

        [Free]
        public delegate SpanBlock256<T> UnaryOp256Imm8<T>(SpanBlock256<T> src, byte imm8, SpanBlock256<T> dst)
            where T : unmanaged;
    }
}