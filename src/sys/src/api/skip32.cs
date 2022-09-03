//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly uint skip32<T>(in T src, long count)
            => ref Add(ref As<T,uint>(ref edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly uint skip32<T>(in T src, ulong count)
            => ref Add(ref As<T,uint>(ref edit(src)), (int)count);

        [MethodImpl(Inline)]
        public static ref readonly T skip32k<T,K>(in T src, K count)
            where K : unmanaged
                => ref Add(ref edit(src), (int)u32(count));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint seek32<T>(in T src, ulong count)
            => ref Add(ref As<T,uint>(ref edit(src)), (int)count);

        [MethodImpl(Inline)]
        public static ref T seek32k<T,K>(in T src, K count)
            where K : unmanaged
                => ref Add(ref edit(src), (int)u32(count));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly int skip32i<T>(in T src, long count)
            => ref Add(ref As<T,int>(ref edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly int skip32i<T>(in T src, ulong count)
            => ref Add(ref As<T,int>(ref edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly int skip32i<T>(ReadOnlySpan<T> src, long count)
            => ref Add(ref As<T,int>(ref edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly int skip32i<T>(ReadOnlySpan<T> src, ulong count)
            => ref Add(ref As<T,int>(ref edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly uint skip32<T>(ReadOnlySpan<T> src, ulong count)
            => ref Add(ref As<T,uint>(ref edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly uint skip32<T>(ReadOnlySpan<T> src, long count)
            => ref Add(ref As<T,uint>(ref edit(first(src))), (int)count);
    }
}