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
        const NumericKind Closure = UnsignedInts;

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
            => (v64u(ConvertToVector256Int64(gptr(src[offset]))),
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
            => (v64u(ConvertToVector256Int64(gptr(src[offset]))),
                v64u(ConvertToVector256Int64(gptr(src[offset],4))));

        /// <summary>
        /// VPMOVZXWD ymm, m128
        /// 16x16u ->16x32u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector512<uint> vinflate512x32u(SpanBlock256<ushort> src, uint offset)
            => (v32u(ConvertToVector256Int32(gptr(src[offset]))),
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

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> inflate16u(in ByteBlock8 src)
            => recover<char>(sys.bytes(vcpu.vlo(vpack.vinflate256x16u(vcpu.vbytes(w128, u64(src))))));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> inflate16u(in ByteBlock16 src)
            => recover<char>(sys.bytes(vcpu.vlo(vpack.vinflate256x16u(vcpu.vbytes(w128, u64(src))))));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> inflate16u(in ByteBlock32 src)
        {
            var v = vload(w256, src.Bytes);
            var lo = vpack.vinflatelo256x16u(v);
            var hi = vpack.vinflatehi256x16u(v);
            return recover<char>(sys.bytes(new V256x2(lo,hi)));
        }


        /// <summary>
        /// VPMOVSXWD ymm, m128
        /// 16x16u ->16x32u
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector512<int> vinflate512x32i(SpanBlock128<short> src, uint offset)
            => (ConvertToVector256Int32(gptr(src[offset])),
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