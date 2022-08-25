//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents a parametric source reference to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static long int64<T>(T src)
             => @as<T,long>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int int32<T>(T src)
             => @as<T,int>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static sbyte int8<T>(T src)
             => @as<T,sbyte>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static short int16<T>(T src)
             => @as<T,short>(src);
    }
}