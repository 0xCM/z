//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    
    partial struct core
    {
        /// <summary>
        /// Returns the number of cells in an array
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count<T>(T[] src)
            => (uint)(src?.Length ?? 0);

        /// <summary>
        /// Returns the number of cells in a span
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count<T>(ReadOnlySpan<T> src)
            => (uint)src.Length;

        /// <summary>
        /// Returns the number of cells in a span
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count<T>(Span<T> src)
            => (uint)src.Length;

        /// <summary>
        /// Counts the number of values in the source that satisfy the predicate
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="f">The predicate to evaluate over each element</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int count<T>(ReadOnlySpan<T> src, Func<T,bool> f)
        {
            int count = 0;
            for(var i=0u; i<src.Length; i++)
                if(f(sys.skip(src,i)))
                    count++;
            return count;
        }

        /// <summary>
        /// Computes the whole number of T-cells identified by a reference
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count<T>(MemorySegment src)
            => (uint)(src.Length/size<T>());
    }
}