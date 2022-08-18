//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents a T-references as a <see cref='short'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref short i16<T>(in T src)
            => ref @as<T,short>(src);

        [MethodImpl(Inline)]
        public static ref short int16<T>(in T src)
             => ref @as<T,short>(src);
    }
}