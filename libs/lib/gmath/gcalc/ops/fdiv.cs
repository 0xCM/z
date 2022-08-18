//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct gcalc
    {
        /// <summary>
        /// Computes the floating-point quotient of cells in the left and right operands,
        /// overwriting each left operand cell with the result.
        /// Specifically, lhs[i] = lhs[i] / rhs[i] for i = 0...n - 1 where n is the common length of the operands
        /// </summary>
        /// <param name="lhs">The left source span</param>
        /// <param name="rhs">The right source span</param>
        /// <typeparam name="T">The floating-point type</typeparam>
        [MethodImpl(Inline), Div, Closures(Floats)]
        public static Span<T> fdiv<T>(Span<T> lhs, ReadOnlySpan<T> rhs)
            where T : unmanaged
        {
            var count = math.min(lhs.Length, rhs.Length);
            ref readonly var a = ref first(lhs);
            ref readonly var b = ref first(rhs);
            ref var c = ref first(lhs);
            for(var i=0; i<count; i++)
                seek(c, i) = gfp.div(skip(a, i), skip(b, i));
            return lhs;
        }

        /// <summary>
        /// Computes the floating-point quotient of cells in the left and right operands,
        /// and writes the result in the target operand
        /// Specifically, dst[i] = lhs[i] / rhs[i] for i = 0...n - 1 where n is the common length of the operands
        /// </summary>
        /// <param name="lhs">The left integer source</param>
        /// <param name="rhs">The right integer source</param>
        /// <typeparam name="T">The primal floating-point type</typeparam>
        [MethodImpl(Inline), Div, Closures(Floats)]
        public static Span<T> fdiv<T>(ReadOnlySpan<T> lhs, ReadOnlySpan<T> rhs, Span<T> dst)
            where T : unmanaged
        {
            var count = math.min(lhs.Length, dst.Length);
            ref readonly var a = ref first(lhs);
            ref readonly var b = ref first(rhs);
            ref var c = ref first(dst);
            for(var i=0; i<count; i++)
                seek(c, i) = gfp.div(skip(a, i), skip(b, i));
            return dst;
        }

        /// <summary>
        /// Computes in-place the quotient of each source element in the left operand and the right operand
        /// </summary>
        /// <param name="src">The left source span</param>
        /// <param name="rhs">The right source span</param>
        /// <typeparam name="T">The floating-point type</typeparam>
        [MethodImpl(Inline), Div, Closures(Floats)]
        public static Span<T> fdiv<T>(Span<T> src, T rhs)
            where T : unmanaged
        {
            var count = src.Length;
            ref readonly var a = ref first(src);
            ref var b = ref first(src);
            for(var i =0; i<count; i++)
                seek(b, i) = gfp.div(skip(a, i), rhs);
            return src;
        }
    }
}