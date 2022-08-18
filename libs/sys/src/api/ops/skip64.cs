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
        public static ref readonly ulong skip64<T>(in T src, long count)
            => ref Add(ref As<T,ulong>(ref edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ulong skip64<T>(in T src, ulong count)
            => ref Add(ref As<T,ulong>(ref edit(src)), (int)count);

        [MethodImpl(Inline)]
        public static ref readonly T skip64k<T,K>(in T src, K count)
            where K : unmanaged
                => ref Add(ref edit(src), (int)u64(count));
    }
}