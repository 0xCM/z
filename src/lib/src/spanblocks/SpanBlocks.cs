//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static sys;

    [ApiHost]
    public readonly partial struct SpanBlocks
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Returns true if all source blocks satisfy a specified unary predicate
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="f">The reified predicate</param>
        /// <typeparam name="F">The predicate reification type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit all<F,T>(in SpanBlock128<T> src, F f)
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
        public static bit all<F,T>(in SpanBlock256<T> src, F f)
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
        public static bit all<F,T>(in SpanBlock128<T> a, in SpanBlock128<T> b, F f)
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
        public static bit all<F,T>(in SpanBlock256<T> a, in SpanBlock256<T> b, F f)
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
        public static ref readonly SpanBlock128<T> map<F,T>(in SpanBlock128<T> src, in SpanBlock128<T> dst, F f)
            where T : unmanaged
            where F : IUnaryOp128<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block < blocks; block++)
                f.Invoke(src.LoadVector(block)).StoreTo(dst, block);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref readonly SpanBlock256<T> map<F,T>(in SpanBlock256<T> src, in SpanBlock256<T> dst, F f)
            where T : unmanaged
            where F : IUnaryOp256<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(src.LoadVector(block)).StoreTo(dst, block);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static Span<bit> map<F,T>(in SpanBlock128<T> src, in Span<bit> dst, F f)
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
        public static Span<bit> map<F,T>(in SpanBlock256<T> src, Span<bit> dst, F f)
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
        public static ref readonly SpanBlock16<T> zip<F,T>(in SpanBlock16<T> a, in SpanBlock16<T> b, in SpanBlock16<T> dst, F f)
            where T : unmanaged
            where F : IBinarySpanOp<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(a.CellBlock(block), b.CellBlock(block), dst);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref readonly SpanBlock32<T> zip<F,T>(in SpanBlock32<T> a, in SpanBlock32<T> b, in SpanBlock32<T> dst, F f)
            where T : unmanaged
            where F : IBinarySpanOp<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(a.CellBlock(block), b.CellBlock(block), dst);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref readonly SpanBlock64<T> zip<F,T>(in SpanBlock64<T> a, in SpanBlock64<T> b, in SpanBlock64<T> dst, F f)
            where T : unmanaged
            where F : IBinarySpanOp<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(a.CellBlock(block), b.CellBlock(block), dst);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref readonly SpanBlock128<T> zip<F,T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst, F f)
            where T : unmanaged
            where F : IBinaryOp128<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(a.LoadVector(block), b.LoadVector(block)).StoreTo(dst, block);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref readonly SpanBlock256<T> zip<F,T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst, F f)
            where T : unmanaged
            where F : IBinaryOp256<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(a.LoadVector(block), b.LoadVector(block)).StoreTo(dst, block);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref readonly SpanBlock128<T> zip<F,T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> c, in SpanBlock128<T> dst, F f)
            where T : unmanaged
            where F : ITernaryOp128<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block<blocks; block++)
                f.Invoke(a.LoadVector(block), b.LoadVector(block), c.LoadVector(block)).StoreTo(dst, block);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref readonly SpanBlock256<T> zip<F,T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> c, in SpanBlock256<T> dst, F f)
            where T : unmanaged
            where F : ITernaryOp256<T>
        {
            var blocks = dst.BlockCount;
            for(var block=0; block<blocks; block++)
                f.Invoke(a.LoadVector(block), b.LoadVector(block), c.LoadVector(block)).StoreTo(dst, block);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref readonly SpanBlock128<T> zip<F,T>(in SpanBlock128<T> src, byte imm8, in SpanBlock128<T> dst, F f)
            where T : unmanaged
            where F : IShiftOp128<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block < blocks; block++)
                f.Invoke(src.LoadVector(block),imm8).StoreTo(dst, block);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref readonly SpanBlock256<T> zip<F,T>(in SpanBlock256<T> src, byte imm8, in SpanBlock256<T> dst, F f)
            where T : unmanaged
            where F : IShiftOp256<T>
        {
            var blocks = dst.BlockCount;
            for(var block = 0; block < blocks; block++)
                f.Invoke(src.LoadVector(block),imm8).StoreTo(dst, block);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static Span<bit> zip<F,T>(in SpanBlock128<T> a, SpanBlock128<T> b, Span<bit> dst, F f)
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
        public static Span<bit> zip<F,T>(in SpanBlock256<T> a, in SpanBlock256<T> b, Span<bit> dst, F f)
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
        public delegate ref readonly SpanBlock8<T> UnarySpanOp8<T>(in SpanBlock8<T> src, in SpanBlock8<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock16<T> UnarySpanOp16<T>(in SpanBlock16<T> src, in SpanBlock16<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock32<T> UnarySpanOp32<T>(in SpanBlock32<T> src, in SpanBlock32<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock64<T> UnarySpanOp64<T>(in SpanBlock64<T> src, in SpanBlock64<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock256<T> UnarySpanOp256<T>(in SpanBlock256<T> src, in SpanBlock256<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock128<T> UnarySpanOp128<T>(in SpanBlock128<T> src, in SpanBlock128<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock512<T> UnarySpanOp512<T>(in SpanBlock512<T> src, in SpanBlock512<T> dst)
            where T : unmanaged;
        [Free]
        public delegate ref readonly SpanBlock8<T> BinaryOp8<T>(in SpanBlock8<T> a, in SpanBlock8<T> b, in SpanBlock8<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock16<T> BinaryOp16<T>(in SpanBlock16<T> a, in SpanBlock16<T> b, in SpanBlock16<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock32<T> BinaryOp32<T>(in SpanBlock32<T> a, in SpanBlock32<T> b, in SpanBlock32<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock64<T> BinaryOp64<T>(in SpanBlock64<T> a, in SpanBlock64<T> b, in SpanBlock64<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock128<T> BinaryOp128<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock256<T> BinaryOp256<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock512<T> BinaryOp512<T>(in SpanBlock512<T> a, in SpanBlock512<T> b, in SpanBlock512<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock128<T> UnaryOp128Imm8<T>(in SpanBlock128<T> src, byte imm8, in SpanBlock128<T> dst)
            where T : unmanaged;

        [Free]
        public delegate ref readonly SpanBlock256<T> UnaryOp256Imm8<T>(in SpanBlock256<T> src, byte imm8, in SpanBlock256<T> dst)
            where T : unmanaged;
    }
}