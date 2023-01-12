//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cells
    {
        /// <summary>
        /// Returns a generic reference to the leading storage cell of an 8-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <typeparam name="T">The reference cell type, of maximal width=8</typeparam>
        [MethodImpl(Inline), Op, Closures(Numeric8k)]
        public static ref T to<T>(in Cell8 src)
            where T : unmanaged
                => ref first(src, default(T));

        /// <summary>
        /// Returns a generic reference to the leading storage cell of a 16-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <typeparam name="T">The reference cell type, of maximal width=16</typeparam>
        [MethodImpl(Inline), Op, Closures(Numeric8x16k)]
        public static ref T to<T>(in Cell16 src)
            where T : unmanaged
                => ref first(src, default(T));

        /// <summary>
        /// Returns a generic reference to the leading storage cell of a 32-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <typeparam name="T">The reference cell type, of maximal width=32</typeparam>
        [MethodImpl(Inline), Op, Closures(Numeric8x16x32k)]
        public static ref T to<T>(in Cell32 src)
            where T : unmanaged
                => ref first(src, default(T));

        /// <summary>
        /// Returns a generic reference to the leading storage cell of a 64-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <typeparam name="T">The reference cell type, of maximal width=64</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T to<T>(in Cell64 src)
            where T : unmanaged
                => ref first(src, default(T));

        /// <summary>
        /// Returns a generic reference to the leading storage cell of a 128-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <typeparam name="T">The reference cell type, of maximal width=128</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T to<T>(in Cell128 src)
            where T : unmanaged
                => ref first(src, default(T));

        /// <summary>
        /// Returns a generic reference to the leading storage cell of a 256-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <typeparam name="T">The reference cell type, of maximal width=256</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T to<T>(in Cell256 src)
            where T : unmanaged
                => ref first(src, default(T));

        /// <summary>
        /// Returns a generic reference to the leading storage cell of a 512-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <typeparam name="T">The reference cell type, of maximal width=512</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T to<T>(in Cell512 src)
            where T : unmanaged
                => ref first(src, default(T));

        [MethodImpl(Inline)]
        static ref T first<F,T>(in F src, T t)
            where F : unmanaged, IDataCell
            where T : unmanaged
                => ref Unsafe.As<F,T>(ref edit(src));
    }
}