//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public static class PolyShuffle
    {
        const NumericKind Closure = AllNumeric;

        /// <summary>
        /// Shuffles span content in-place
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="target">The input/output span</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static Span<T> Shuffle<T>(this IBoundSource src, Span<T> target)
            => shuffle(src,target);

        /// <summary>
        /// Replicates and shuffles a source span
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> Shuffle<T>(this IBoundSource random, ReadOnlySpan<T> src)
            => random.Shuffle(src.Replicate());

        /// <summary>
        /// Shuffles span content in-place
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The input/output span</param>
        /// <typeparam name="T">The primal type</typeparam>
        [Op, Closures(Closure)]
        public static Span<T> shuffle<T>(IBoundSource src, Span<T> dst)
        {
            for (var i = 0u; i<dst.Length; i++)
                Swaps.swap(ref sys.seek(dst,i), ref sys.seek(dst,(uint)(i + src.Next(0, dst.Length - i))));
            return dst;
        }
    }
}