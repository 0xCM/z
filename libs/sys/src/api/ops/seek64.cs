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
        public static ref ulong seek64<T>(in T src, ulong count)
            => ref Add(ref As<T,ulong>(ref edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref long seek64i<T>(in T src, ulong count)
            => ref Add(ref As<T,long>(ref edit(src)), (int)count);
            
        [MethodImpl(Inline)]
        public static ref T seek64k<T,K>(in T src, K count)
            where K : unmanaged
                => ref Add(ref edit(src), (int)u64(count));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ulong seek64<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,ulong>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref long seek64i<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,long>(ref first(src)), (int)count);
    }
}