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
        public static ref ushort seek16<T>(in T src, ulong count)
            => ref Add(ref As<T,ushort>(ref edit(src)), (int)count);

        [MethodImpl(Inline)]
        public static ref T seek16k<T,K>(in T src, K count)
            where K : unmanaged
                => ref Add(ref edit(src), u16(count));
    }
}