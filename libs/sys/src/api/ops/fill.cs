//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    
    partial class sys
    {
        /// <summary>
        /// Populates each cell of a target span with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static void fill<T>(T src, Span<T> dst)
            => dst.Fill(src);

        /// <summary>
        /// Overwrites a reference-identified memory segment with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The leading target cell</param>
        /// <param name="length">The byte-measured segment length</param>
        [MethodImpl(Options), Op]
        public static ref byte fill(byte src, ref byte dst, uint length)
        {
            InitBlock(ref dst, src, length);
            return ref dst;
        }

        /// <summary>
        /// Fills an array, in-place, with a specified value
        /// </summary>
        /// <param name="dst">The target array</param>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] fill<T>(T[] dst, T src)
        {
            Array.Fill(dst, src);
            return dst;
        }        
    }
}