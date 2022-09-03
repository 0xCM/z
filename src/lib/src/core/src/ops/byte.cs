//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial struct core
    {
        /// <summary>
        /// Forcefully coerces a <see cref='bool'/> to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static unsafe byte @byte(bool src)
            => (*((byte*)(&src)));

        /// <summary>
        /// Presents generic reference as a <see cref='byte'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte @byte<T>(in T src)
            where T : unmanaged
                => ref As<T,byte>(ref edit(src));

        [MethodImpl(Inline), Op]
        public static unsafe byte @byte(in ulong src, byte index)
            => *((byte*)gptr(src) + index);
    }
}