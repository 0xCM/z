//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Presents a <see cref='bool'/> to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static unsafe byte u8(bool src)
            => *((byte*)(&src));

        /// <summary>
        /// Presents a T-references as a <see cref='byte'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte u8<T>(in T src)
            => ref @as<T,byte>(src);

        /// <summary>
        /// Adds a byte-measured offset to a parametric reference and presents the result as a <see cref='byte'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="offset">The offset count, measured in bytes</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte u8<T>(in T src, int offset)
            => ref add(@as<T,byte>(src), offset);

        /// <summary>
        /// Reads a bytes from the data source, if present; otherewise, returns 0
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref readonly byte u8(ReadOnlySpan<byte> src)
            => ref first(src);

        [MethodImpl(Inline), Op]
        public static ref readonly byte u8(ReadOnlySpan<byte> src, uint offset)
            => ref skip(src, offset);
    }
}