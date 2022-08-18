//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Presents a <see cref='bool'/> as a <see cref='uint'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static unsafe uint u32(bool src)
            => *((byte*)(&src));

        /// <summary>
        /// Presents a parametric references as a <see cref='uint'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint u32<T>(in T src)
            => ref @as<T,uint>(src);

        /// <summary>
        /// Adds a <see cref='uint'/> measured offset to a parametric reference and presents the resulting cell
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="offset">The offset count, measured in bytes</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint u32<T>(in T src, int offset)
            => ref add(@as<T,uint>(src), offset);

        [MethodImpl(Inline), Op]
        public static uint u32(ReadOnlySpan<byte> src)
            => first32u(src);

        [MethodImpl(Inline), Op]
        public static uint u32(ReadOnlySpan<byte> src, uint offset)
            => skip32(src, offset);
    }
}