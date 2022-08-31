//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static float float32<T>(T src)
            => As<T,float>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref float float32<T>(ref T src)
            => ref As<T,float>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T float32<T>(in float src, out T dst)
        {
            dst = @as<float,T>(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref float float32<T>(in T src, out float dst)
        {
            dst = @as<T,float>(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static float? float32<T>(T? src)
            where T : unmanaged
                => As<T?,float?>(ref src);
    }
}