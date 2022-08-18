//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class BitVectors
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong seg64<T>(BitVector256<T> src, N0 n)
            where T : unmanaged
                => gcpu.vcell64(src.State, 0);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong seg64<T>(BitVector256<T> src, N1 n)
            where T : unmanaged
                => gcpu.vcell64(src.State, 1);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong seg64<T>(BitVector256<T> src, N2 n)
            where T : unmanaged
                => gcpu.vcell64(src.State, 2);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong seg64<T>(BitVector256<T> src, N3 n)
            where T : unmanaged
                => gcpu.vcell64(src.State, 3);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte seg8<T>(BitVector256<T> src, byte pos)
            where T : unmanaged
                => gcpu.vcell8(src.State, pos);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ushort seg16<T>(BitVector256<T> src, byte pos)
            where T : unmanaged
                => gcpu.vcell16(src.State, pos);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint seg32<T>(BitVector256<T> src, byte pos)
            where T : unmanaged
                => gcpu.vcell32(src.State, pos);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint seg64<T>(BitVector256<T> src, byte pos)
            where T : unmanaged
                => gcpu.vcell32(src.State, pos);
    }
}