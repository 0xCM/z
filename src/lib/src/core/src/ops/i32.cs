//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Presents a <see cref='bool'/> as a <see cref='int'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static unsafe int i32(bool src)
            => *((sbyte*)(&src));

        /// <summary>
        /// Presents a <see cref='float'/> value as an <see cref='int'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static unsafe int i32(float src)
            => (*((int*)(&src)));

        /// <summary>
        /// Presents a T-references as a <see cref='int'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref int i32<T>(in T src)
            => ref @as<T,int>(src);

        /// <summary>
        /// Adds a <see cref='int'/> measured offset to a parametric reference and presents the resulting as a <see cref='int'/> cell reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="offset">The offset count, measured in bytes</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref int i32<T>(in T src, int offset)
            => ref add(@as<T,int>(src), offset);

        [MethodImpl(Inline), Op]
        public static ref readonly int i32(ReadOnlySpan<byte> src)
            => ref first32i(src);

        [MethodImpl(Inline), Op]
        public static ref int i32(Span<byte> src)
            => ref first32i(src);
    }
}