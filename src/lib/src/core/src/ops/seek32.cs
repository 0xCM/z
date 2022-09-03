//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint seek32<T>(in T src, ulong count)
            => ref Add(ref As<T,uint>(ref edit(src)), (int)count);

        [MethodImpl(Inline)]
        public static ref T seek32k<T,K>(in T src, K count)
            where K : unmanaged
                => ref Add(ref edit(src), (int)u32(count));
    }
}