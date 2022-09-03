//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Observations
    {
        /// <summary>
        /// Loads a sample from an array
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="dim">The sample dimension</param>
        /// <param name="offset">The offset into the source span from to begin the load</param>
        /// <typeparam name="T">The sample data type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Observations<T> Load<T>(T[] src, int dim = 1)
            where T : unmanaged
                => new Observations<T>(src, dim);

        /// <summary>
        /// Loads a sample from a span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="dim">The sample dimension</param>
        /// <param name="offset">The offset into the source span from to begin the load</param>
        /// <typeparam name="T">The sample data type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Observations<T> Load<T>(Span<T> src, int dim = 1)
            where T : unmanaged
                => new Observations<T>(src, dim);

        /// <summary>
        /// Allocates a sample
        /// </summary>
        /// <param name="dim">The sample dimension</param>
        /// <param name="count">The number of observation vectors in the sample</param>
        /// <typeparam name="T">The sample data type</typeparam>
        [Op, Closures(UnsignedInts)]
        public static Observations<T> Alloc<T>(int dim, int count)
            where T : unmanaged
                => new Observations<T>(sys.alloc<T>(count * dim), dim);
    }
}