//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        /// <summary>
        /// Creates a <see cref='List<T>'/> from a parameter array
        /// </summary>
        /// <param name="src">The source elements</param>
        /// <typeparam name="T">The element type</typeparam>
        [Op, Closures(Closure)]
        public static List<T> list<T>(params T[] src)
        {
            var length = src?.Length ?? 0;
            if(length == 0)
                return new List<T>();
            else
            {
                var dst = new List<T>(length);
                dst.AddRange(src);
                return dst;
            }
        }

        /// <summary>
        /// Creates a list with specified capacity
        /// </summary>
        /// <param name="capacity">The list capacity</param>
        /// <typeparam name="T">The item type</typeparam>
        [Op, Closures(AllNumeric)]
        public static List<T> list<T>(int capacity)
            => new List<T>(capacity);

        /// <summary>
        /// Creates a list with specified capacity
        /// </summary>
        /// <param name="capacity">The list capacity</param>
        /// <typeparam name="T">The item type</typeparam>
        [Op, Closures(AllNumeric)]
        public static List<T> list<T>(uint capacity)
            => new List<T>((int)capacity);
    }
}