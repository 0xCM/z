//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ByteBlocks
    {
        /// <summary>
        /// Presents the leading source storage cell as a generic reference
        /// </summary>
        /// <param name="src">The source storage</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T first<T>(ref ByteBlock8 src)
            where T : unmanaged
                => ref @as<ulong,T>(u64(src));

        /// <summary>
        /// Presents the leading source storage cell as a generic reference
        /// </summary>
        /// <param name="src">The source storage</param>
        /// <param name="t">A cell type representative</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T first<T>(ref ByteBlock16 src)
            where T : unmanaged
                => ref @as<ulong,T>(u64(src));

        /// <summary>
        /// Presents the leading source storage cell as a generic reference
        /// </summary>
        /// <param name="src">The source storage</param>
        /// <param name="t">A cell type representative</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T first<T>(ref ByteBlock32 src)
            where T : unmanaged
                => ref @as<ulong,T>(u64(src));

        /// <summary>
        /// Presents the leading source storage cell as a generic reference
        /// </summary>
        /// <param name="src">The source storage</param>
        /// <param name="t">A cell type representative</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T first<T>(ref ByteBlock64 src)
            where T : unmanaged
                => ref @as<ulong,T>(u64(src));

        /// <summary>
        /// Presents the leading source storage cell as a generic reference
        /// </summary>
        /// <param name="src">The source storage</param>
        /// <param name="t">A cell type representative</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T first<T>(ref ByteBlock128 src)
            where T : unmanaged
                => ref @as<ulong,T>(u64(src));
    }
}