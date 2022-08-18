//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(BitVector128<T> src, Span<T> dst)
            where T : unmanaged
                => gcpu.vstore(src.State,  dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(BitVector128<T> src, Span<byte> dst)
            where T : unmanaged
                => gcpu.vstore(cpu.v8u(src.State),  dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(BitVector256<T> src, Span<T> dst)
            where T : unmanaged
                => gcpu.vstore(src.State,  dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(BitVector256<T> src, Span<byte> dst)
            where T : unmanaged
                => gcpu.vstore(cpu.v8u(src.State),  dst);
    }
}