//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        /// <summary>
        /// Projects a range of elements from a source span to a target span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The source offset</param>
        /// <param name="length">The length of the segment to project</param>
        /// <param name="f">The projector</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        public static T[] MapRange<S,T>(this ReadOnlySpan<S> src, int offset, int length, Func<S,T> f)
        {
            var dst = new T[length];
            for (uint i = (uint)offset; i<length; i++)
                seek(dst,i) = f(sys.skip(src,i));
            return dst;
        }

        /// <summary>
        /// Projects a range of elements from a source span to a target span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The source offset</param>
        /// <param name="length">The length of the segment to project</param>
        /// <param name="f">The projector</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T[] MapRange<S,T>(this Span<S> src, int offset, int length, Func<S,T> f)
            => src.ReadOnly().MapRange(offset,length, f);

        /// <summary>
        /// Projects a source span to target span via a supplied transformation
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="f">The transformation</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        public static T[] MapArray<S,T>(this ReadOnlySpan<S> src, Func<S,T> f)
        {
            var buffer = new T[src.Length];
            map(src,f,buffer);
            return buffer;
       }
    }
}