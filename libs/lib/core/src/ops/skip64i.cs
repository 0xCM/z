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
        public static ref readonly long skip64i<T>(in T src, long count)
            => ref Add(ref As<T,long>(ref edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly long skip64i<T>(in T src, ulong count)
            => ref Add(ref As<T,long>(ref edit(src)), (int)count);
    }
}