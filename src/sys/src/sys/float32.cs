//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static float float32<T>(T src)
            => As<T,float>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T float32<T>(in float src, out T dst)
        {
            dst = @as<float,T>(src);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static float float32<T>(in T src, out float dst)
        {
            dst = @as<T,float>(src);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static float? float32<T>(T? src)
            where T : unmanaged
                => As<T?,float?>(ref src);
                
        /// <summary>
        /// Presents a readonly span of generic values as a readonly span of 32-bit floats
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<float> float32<T>(Span<T> src)
            where T : unmanaged
                => recover<T,float>(src);

        /// <summary>
        /// Presents a readonly span of generic values as a readonly span of 32-bit floats
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<float> float32<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => recover<T,float>(src);
    }
}