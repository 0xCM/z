//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class Scalars
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static sbyte int8<T>(T src)
            => As<T,sbyte>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static short int16<T>(T src)
            => As<T,short>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int int32<T>(T src)
            => sys.@as<T,int>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static long int64<T>(T src)
            => sys.@as<T,long>(src);

        /// <summary>
        /// Converts a parametric source to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte uint8<T>(T src)
            => sys.@as<T,byte>(src);

        /// <summary>
        /// Presents a parametric source to a <see cref='ushort'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ushort uint16<T>(T src)
            => sys.@as<T,ushort>(src);

        /// <summary>
        /// Presents a parametric source to a <see cref='uint'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint uint32<T>(T src)
            => sys.@as<T,uint>(src);

        /// <summary>
        /// Converts a parametric source to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong uint64<T>(T src)
            => sys.@as<T,ulong>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static float float32<T>(T src)
            => sys.@as<T,float>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static double float64<T>(T src)
            => sys.@as<T,double>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool @bool<T>(T src)
            => sys.@as<T,bool>(src);

        /// <summary>
        /// Presents a parametric reference as a <see cref='char'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static char c16<T>(T src)
            => sys.@as<T,char>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static decimal float128<T>(T src)
            => As<T,decimal>(ref src);
    }
}