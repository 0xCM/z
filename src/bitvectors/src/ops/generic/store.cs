//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static vgcpu;

    partial class BitVectors
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(BitVector128<T> src, Span<T> dst)
            where T : unmanaged
                => vstore(src.State,  dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(BitVector128<T> src, Span<byte> dst)
            where T : unmanaged
                => vstore(vcpu.v8u(src.State),  dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(BitVector256<T> src, Span<T> dst)
            where T : unmanaged
                => vstore(src.State,  dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(BitVector256<T> src, Span<byte> dst)
            where T : unmanaged
                => vstore(vcpu.v8u(src.State),  dst);
    }
}