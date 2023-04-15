//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Permute
    {
        /// <summary>
        /// Shuffles span content as determined by a permutation
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="p">The permutation to apply</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void apply<T>(Perm p, ReadOnlySpan<T> src, Span<T> dst)
        {
            var terms = p.Terms.View;
            var count = terms.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = skip(src,(uint)skip(terms,i));
        }

        /// <summary>
        /// Applies a sequence of transpositions to source span elements
        /// </summary>
        /// <param name="src">The source and target span</param>
        /// <param name="i">The first index</param>
        /// <param name="j">The second index</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void apply<T>(Span<T> src, params Swap[] swaps)
            where T : unmanaged
        {
            var len = swaps.Length;
            ref var swap = ref first(swaps);
            for(var k = 0u; k<len; k++)
            {
                (var i, var j) = skip(swap, k);
               Swaps.swap(ref seek(src, i), ref seek(src, j));
            }
        }

        /// <summary>
        /// Applies a transposition sequence to an input sequence
        /// </summary>
        /// <param name="src">The input sequence</param>
        /// <param name="swaps">The transposition sequence</param>
        /// <param name="dst">The output sequence</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void apply<T>(ReadOnlySpan<T> src, ReadOnlySpan<Swap> swaps, Span<T> dst)
            where T : unmanaged
        {
            var len = swaps.Length;
            ref readonly var input = ref first(src);
            ref readonly var exchange = ref first(swaps);
            for(var k = 0u; k<len; k++)
            {
                ref readonly var x = ref skip(exchange, k);
                Swaps.swap(ref seek(input, x.i), ref seek(input, x.j));
            }
        }
    }
}