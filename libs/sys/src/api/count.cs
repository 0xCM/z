//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count<T>(ReadOnlySpan<T> src, Func<T,bool> f)
        {
            var k = 0u;
            for(var i=0; i<src.Length; i++)
            {
                if(f(skip(src,i)))
                    k++;
            }
            return k;
        }


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
        /// Computes the whole number of T-cells identified by a reference
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count<T>(MemorySeg src)
            => (uint)(src.Length/size<T>());
    }
}