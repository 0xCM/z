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
        public static ref readonly byte skip8<T>(in T src, long count)
            => ref sys.add(@as<T,byte>(edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly byte skip8<T>(in T src, ulong count)
            => ref sys.add(@as<T,byte>(edit(src)), (int)count);

        [MethodImpl(Inline)]
        public static ref readonly T skip8k<T,K>(in T src, K count)
            where K : unmanaged
                => ref Add(ref edit(src), u8(count));
    }
}