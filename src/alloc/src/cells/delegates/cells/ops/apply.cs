//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class CellDelegates
    {
        [MethodImpl(Inline), Op]
        public static Cell8 apply(UnaryOp8 f, Cell8 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static Cell16 apply(UnaryOp16 f, Cell16 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static Cell32 apply(UnaryOp32 f, Cell32 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static Cell64 apply(UnaryOp64 f, Cell64 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static Cell128 apply(UnaryOp128 f, Cell128 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static Cell256 apply(UnaryOp256 f, Cell256 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static Cell512 apply(UnaryOp512 f, Cell512 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static Cell8 apply(BinaryOp8 f, in Cell8 a, in Cell8 b)
            => f(a,b);

        [MethodImpl(Inline), Op]
        public static Cell16 apply(BinaryOp16 f, in Cell16 a, in Cell16 b)
            => f(a,b);

        [MethodImpl(Inline), Op]
        public static Cell32 apply(BinaryOp32 f, in Cell32 a, in Cell32 b)
            => f(a,b);

        [MethodImpl(Inline), Op]
        public static Cell64 apply(BinaryOp64 f, in Cell64 a, in Cell64 b)
            => f(a,b);

        [MethodImpl(Inline), Op]
        public static Cell128 apply(BinaryOp128 f, in Cell128 a, in Cell128 b)
            => f(a,b);

        [MethodImpl(Inline), Op]
        public static Cell256 apply(BinaryOp256 f, in Cell256 a, in Cell256 b)
            => f(a,b);

        [MethodImpl(Inline), Op]
        public static Cell512 apply(BinaryOp512 f, in Cell512 a, in Cell512 b)
            => f(a,b);

        /// <summary>
        /// Applies a unary operator to an input sequence and deposits the result to a caller-supplied target
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="f">The operator</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void apply<T>(ReadOnlySpan<T> src, UnaryOp<T> f, Span<T> dst)
        {
            var count = length(src,dst);
            for(var i= 0u; i<count; i++)
                seek(dst,i) = f(skip(src,i));
        }

        /// <summary>
        /// Projects a pair of source spans to target span via a binary operator
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        /// <param name="f">The operator</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void apply<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, BinaryOp<T> f, Span<T> dst)
        {
            var count = length(x,y);
            for(var i= 0u; i<count; i++)
                seek(dst,i) = f(skip(x,i), skip(y,i));
        }

        /// <summary>
        /// Evaluates a 128-bit unary operator over a vector
        /// </summary>
        /// <param name="f">The operator</param>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> apply<T>(UnaryOp128 f, Vector128<T> x)
            where T : unmanaged
                => f(x.ToCell()).ToVector<T>();

        /// <summary>
        /// Evaluates a 256-bit unary operator over a vector
        /// </summary>
        /// <param name="f">The operator</param>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> apply<T>(UnaryOp256 f, Vector256<T> x)
            where T : unmanaged
                => f(x.ToCell()).ToVector<T>();

        /// <summary>
        /// Evaluates a 512-bit unary operator over a vector
        /// </summary>
        /// <param name="f">The operator</param>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> apply<T>(UnaryOp512 f, in Vector512<T> x)
            where T : unmanaged
                => f(x.ToCell()).ToVector<T>();

        /// <summary>
        /// Evaluates a 128-bit binary operator over a pair of vectors
        /// </summary>
        /// <param name="f">The operator</param>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> apply<T>(BinaryOp128 f, Vector128<T> x, Vector128<T> y)
            where T : unmanaged
                => f(x.ToCell(), y.ToCell()).ToVector<T>();

        /// <summary>
        /// Evaluates a 256-bit binary operator over a pair of vectors
        /// </summary>
        /// <param name="f">The operator</param>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> apply<T>(BinaryOp256 f, Vector256<T> x, Vector256<T> y)
            where T : unmanaged
                => f(x.ToCell(), y.ToCell()).ToVector<T>();

        /// <summary>
        /// Evaluates a 512-bit binary operator over a pair of vectors
        /// </summary>
        /// <param name="f">The operator</param>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> apply<T>(BinaryOp512 f, Vector512<T> x, Vector512<T> y)
            where T : unmanaged
                => f(x.ToCell(), y.ToCell()).ToVector<T>();    
    }
}
