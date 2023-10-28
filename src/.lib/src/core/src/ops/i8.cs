//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Presents a <see cref='bool'/> as a <see cref='sbyte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static unsafe sbyte i8(bool src)
            => *((sbyte*)(&src));

        /// <summary>
        /// Presents a <typeparamref name='T'/> reference as an <see cref='sbyte'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte i8<T>(in T src)
            => ref @as<T,sbyte>(src);

        [MethodImpl(Inline), Op]
        public static ref sbyte i8(Span<byte> src)
            => ref @as<byte,sbyte>(first(src));

        [MethodImpl(Inline), Op]
        public static ref sbyte i8(Span<byte> src, uint offset)
            => ref @as<byte,sbyte>(skip(src, offset));

        [MethodImpl(Inline), Op]
        public static ref readonly sbyte i8(ReadOnlySpan<byte> src)
            => ref @as<byte,sbyte>(first(src));

        [MethodImpl(Inline), Op]
        public static ref readonly sbyte i8(ReadOnlySpan<byte> src, uint offset)
            => ref @as<byte,sbyte>(skip(src, offset));
    }
}