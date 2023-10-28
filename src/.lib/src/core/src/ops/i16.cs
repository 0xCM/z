//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct core
    {
        /// <summary>
        /// Presents a <see cref='bool'/> as a <see cref='short'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static unsafe short i16(bool src)
            => *((sbyte*)(&src));

        /// <summary>
        /// Presents a T-references as a <see cref='short'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref short i16<T>(in T src)
            => ref @as<T,short>(src);

        /// <summary>
        /// Adds a <see cref='short'/> measured offset to a parametric reference and presents the resulting as a <see cref='short'/> cell reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="offset">The offset count, measured in bytes</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref short i16<T>(in T src, int offset)
            => ref add(@as<T,short>(src), offset);
    }
}