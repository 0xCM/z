//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cells
    {
        /// <summary>
        /// Creates an 8-bit value
        /// </summary>
        /// <param name="w">The bit-width selector</typeparam>
        [MethodImpl(Inline), Op]
        public static Cell8 alloc(W8 w)
            => default(Cell8);

        /// <summary>
        /// Creates a 16-bit value
        /// </summary>
        /// <param name="w">The bit-width selector</typeparam>
        [MethodImpl(Inline), Op]
        public static Cell16 alloc(W16 w)
            => default(Cell16);

        /// <summary>
        /// Creates a 32-bit value
        /// </summary>
        /// <param name="w">The bit-width selector</typeparam>
        [MethodImpl(Inline), Op]
        public static Cell32 alloc(W32 w)
            => default(Cell32);

        /// <summary>
        /// Creates a 64-bit value
        /// </summary>
        /// <param name="w">The bit-width selector</typeparam>
        [MethodImpl(Inline), Op]
        public static Cell64 alloc(W64 w)
            => default(Cell64);

        /// <summary>
        /// Creates a 128-bit value
        /// </summary>
        /// <param name="w">The bit-width selector</typeparam>
        [MethodImpl(Inline), Op]
        public static Cell128 alloc(W128 w)
            => default(Cell128);

        /// <summary>
        /// Creates a 256-bit value
        /// </summary>
        /// <param name="w">The bit-width selector</typeparam>
        [MethodImpl(Inline), Op]
        public static Cell256 alloc(W256 w)
            => default(Cell256);

        /// <summary>
        /// Creates a 512-bit value
        /// </summary>
        /// <param name="w">The bit-width selector</typeparam>
        [MethodImpl(Inline), Op]
        public static Cell512 alloc(W512 w)
            => default(Cell512);

    }
}