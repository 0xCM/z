//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Enums
    {
        [MethodImpl(Inline)]
        public static ReadOnlySpan<E> interpret<E>(ReadOnlySpan<sbyte> src)
            where E : unmanaged, Enum
                => recover<sbyte,E>(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<E> interpret<E>(ReadOnlySpan<byte> src)
            where E : unmanaged, Enum
                => recover<byte,E>(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<E> interpret<E>(ReadOnlySpan<short> src)
            where E : unmanaged, Enum
                => recover<short,E>(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<E> interpret<E>(ReadOnlySpan<ushort> src)
            where E : unmanaged, Enum
                => recover<ushort,E>(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<E> interpret<E>(ReadOnlySpan<int> src)
            where E : unmanaged, Enum
                => recover<int,E>(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<E> interpret<E>(ReadOnlySpan<uint> src)
            where E : unmanaged, Enum
                => recover<uint,E>(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<E> interpret<E>(ReadOnlySpan<long> src)
            where E : unmanaged, Enum
                => recover<long,E>(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<E> interpret<E>(ReadOnlySpan<ulong> src)
            where E : unmanaged, Enum
                => recover<ulong,E>(src);
    }
}