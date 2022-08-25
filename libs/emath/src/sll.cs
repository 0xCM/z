//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct emath
    {
        [MethodImpl(Inline)]
        public static @enum<E,T> sll<E,T>(@enum<E,T> a, byte count)
            where E : unmanaged
            where T : unmanaged
                => new @enum<E,T>(gmath.sll(a.Scalar, count));

        [MethodImpl(Inline)]
        public static byte sll8<E>(E a, byte count)
            where E : unmanaged
                => gmath.sll(bw8(a), count);

        [MethodImpl(Inline)]
        public static ushort sll16<E>(E a, byte count)
            where E : unmanaged
                => gmath.sll(bw16(a), count);

        [MethodImpl(Inline)]
        public static uint sll32<E>(E a, byte count)
            where E : unmanaged
                => gmath.sll(bw32(a), count);

        [MethodImpl(Inline)]
        public static ulong sll64<E>(E a, byte count)
            where E : unmanaged
                => gmath.sll(bw64(a), count);
    }
}