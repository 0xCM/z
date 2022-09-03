//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Widths
    {
        /// <summary>
        /// Counts the number of numeric T-cells that can be covered by contiguous memory of width W
        /// </summary>
        /// <param name="w">The memory bit-width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static int cells<W,T>()
            where W : unmanaged, ITypeWidth
            where T : unmanaged
                => cells_lo<W,T>();

        [MethodImpl(Inline)]
        static int cells_lo<W,T>()
            where W : unmanaged, ITypeWidth
            where T : unmanaged
        {
            if(typeof(W) == typeof(W8))
                return cells<T>(w8);
            else if(typeof(W) == typeof(W16))
                return cells<T>(w16);
            else if(typeof(W) == typeof(W32))
                return cells<T>(w32);
            else if(typeof(W) == typeof(W64))
                return cells<T>(w64);
            else
                return cells_hi<W,T>();
        }

        [MethodImpl(Inline)]
        static int cells_hi<W,T>()
            where W : unmanaged,ITypeWidth
            where T : unmanaged
        {
            if(typeof(W) == typeof(W128))
                return cells<T>(w128);
            else if(typeof(W) == typeof(W256))
                return cells<T>(w256);
            else if(typeof(W) == typeof(W512))
                return cells<T>(w512);
            else if(typeof(W) == typeof(W1024))
                return cells<T>(w1024);
            else
                return 0;
        }

        /// <summary>
        /// Counts the number of numeric T-cells that can be covered by contiguous memory of specified width
        /// </summary>
        /// <param name="w">The memory bit-width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cells<T>(W8 w)
            => 1/(int)bytes<T>();

        /// <summary>
        /// Counts the number of numeric T-cells that can be covered by contiguous memory of specified width
        /// </summary>
        /// <param name="w">The memory bit-width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cells<T>(W16 w)
            => 2/(int)bytes<T>();

        /// <summary>
        /// Counts the number of numeric T-cells that can be covered by contiguous memory of specified width
        /// </summary>
        /// <param name="w">The memory bit-width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cells<T>(W32 w)
            => 4/(int)bytes<T>();

        /// <summary>
        /// Counts the number of numeric T-cells that can be covered by contiguous memory of specified width
        /// </summary>
        /// <param name="w">The memory bit-width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cells<T>(W64 w)
            => 8/(int)bytes<T>();

        /// <summary>
        /// Counts the number of numeric T-cells that can be covered by contiguous memory of specified width
        /// </summary>
        /// <param name="w">The memory bit-width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cells<T>(W128 w)
            where T : unmanaged
                => 16/(int)bytes<T>();

        /// <summary>
        /// Counts the number of numeric T-cells that can be covered by contiguous memory of specified width
        /// </summary>
        /// <param name="w">The memory bit-width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cells<T>(W256 w)
            where T : unmanaged
                => 32/(int)bytes<T>();

        /// <summary>
        /// Counts the number of numeric T-cells that can be covered by contiguous memory of specified width
        /// </summary>
        /// <param name="w">The memory bit-width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cells<T>(W512 w)
            where T : unmanaged
                => 64/(int)bytes<T>();

        /// <summary>
        /// Counts the number of numeric T-cells that can be covered by contiguous memory of specified width
        /// </summary>
        /// <param name="w">The memory bit-width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static int cells<T>(W1024 w)
            where T : unmanaged
                => 128/(int)bytes<T>();
    }
}