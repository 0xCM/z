//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        /// <summary>
        /// Partitions a source stream into sub-arrays of a maximum length
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="max">The maximum sub-array length</param>
        /// <typeparam name="T">The element type</typeparam>
        public static IEnumerable<T[]> Partition<T>(this IEnumerable<T> src, int max)
        {
            var list = new List<T>();
            foreach (var item in src)
            {
                list.Add(item);
                if (list.Count == max)
                {
                    yield return list.ToArray();
                    list = new List<T>();
                }
            }
            if (list.Count != 0)
                yield return list.ToArray();
        }

        /// <summary>
        /// Partitions the source array into a sequence of array segments
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="width">The maximal segment width</param>
        /// <typeparam name="T">The element type</typeparam>
        public static IEnumerable<ArraySegment<T>> Partition<T>(this T[] src, int width)
        {
            var count = Math.DivRem(src.Length,width, out int overflow);
            for(var i = 0; i < count; i++)
                yield return new ArraySegment<T>(src, i*width, width);

            if(overflow != 0)
            {
                var last = new T[width];
                for(var i = count; i< src.Length; i++)
                    last[i] = src[i];
                yield return new ArraySegment<T>(last);
            }
        }

        /// <summary>
        /// Runs through an enumerable in batches
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="source">The item source</param>
        /// <param name="max">The maximum number of elements per batch</param>
        /// <remarks>
        /// Implementation inspired from https://github.com/morelinq/MoreLINQ
        /// </remarks>
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int max)
        {
            var buffer = default(T[]);
            var count = 0;

            foreach (var item in source)
            {
                if (buffer == null)
                    buffer = new T[max];

                buffer[count++] = item;

                if (count != max)
                    continue;
                yield return buffer;

                buffer = null;
                count = 0;
            }

            if (buffer != null && count > 0)
                yield return buffer.Take(count);
        }
    }
}