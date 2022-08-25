//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
    {        
        /// <summary>
        /// Presents a parametric source to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte uint8<T>(T src)
            => As<T,byte>(ref src);

        /// <summary>
        /// Presents a parametric source reference to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte uint8<T>(ref T src)
            => ref As<T,byte>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T uint8<T>(in byte src, out T dst)
        {
            dst = @as<byte,T>(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte uint8<T>(in T src, out byte dst)
        {
            dst = @as<T,byte>(src);
            return ref dst;
        }

        /// <summary>
        /// Converts a nullable parametric source to a nullable <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte? uint8<T>(T? src)
            where T : struct
                => As<T?, byte?>(ref src);

        /// <summary>
        /// Projects a sequence of <typeparamref name='T'/> cells onto a sequence of <see cref='byte'/> cells
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<byte> uint8<T>(Span<T> src)
            where T : struct
                => recover<T,byte>(src);

        /// <summary>
        /// Projects a readonly sequence of <typeparamref name='T'/> cells onto a sequence of readonly <see cref='byte'/> cells
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<byte> uint8<T>(ReadOnlySpan<T> src)
            where T : struct
                => recover<T,byte>(src);    }
}