//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents a parametric source reference to a <see cref='uint'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint uint32<T>(in T src)
             => ref @as<T,uint>(src);

        /// <summary>
        /// Presents a parametric source reference to a <see cref='uint'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref int int32<T>(in T src)
             => ref @as<T,int>(src);

        /// <summary>
        /// Presents a parametric source reference to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ulong uint64<T>(in T src)
             => ref @as<T,ulong>(src);

        /// <summary>
        /// Presents a parametric source reference to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref long int64<T>(in T src)
             => ref @as<T,long>(src);

        /// <summary>
        /// Presents a parametric source reference to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref float float32<T>(in T src)
             => ref @as<T,float>(src);

        /// <summary>
        /// Presents a parametric source reference to a <see cref='double'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref double float64<T>(in T src)
             => ref @as<T,double>(src);
    }
}