//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents a <typeparamref name='T'/> reference as an <see cref='sbyte'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte i8<T>(in T src)
            => ref @as<T,sbyte>(src);

        [MethodImpl(Inline)]
        public static ref sbyte int8<T>(in T src)
             => ref i8(src);
    }
}