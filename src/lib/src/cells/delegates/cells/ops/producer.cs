//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CellDelegates
    {
        [MethodImpl(NotInline), Op]
        public static Producer1 producer(Producer<bit> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Producer8 producer(Producer<sbyte> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Producer8 producer(Producer<byte> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Producer16 producer(Producer<short> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Producer16 producer(Producer<ushort> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Producer32 producer(Producer<int> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Producer32 producer(Producer<uint> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Producer64 producer(Producer<long> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Producer64 producer(Producer<ulong> f)
            => () => f();
    }
}