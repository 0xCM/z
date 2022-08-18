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
        public static ref readonly int skip32i<T>(in T src, long count)
            => ref Add(ref As<T,int>(ref edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly int skip32i<T>(in T src, ulong count)
            => ref Add(ref As<T,int>(ref edit(src)), (int)count);
    }
}