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
        public static bool same<T>(in T a, in T b)
            => Unsafe.AreSame(ref edit(a), ref edit(b));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte seek8<T>(in T src, ulong count)
            => ref add(@as<T,byte>(edit(src)), (int)count);

        [MethodImpl(Inline)]
        public static ref T seek8k<T,K>(in T src, K count)
            where K : unmanaged
                => ref Add(ref edit(src), u8(count));
    }
}