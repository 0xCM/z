//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CellDelegates
    {
        [MethodImpl(NotInline), Op]
        public static UnaryPredicate1 predicate(UnaryPredicate<bit> f)
            => a => f(a);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate8 predicate(UnaryPredicate<sbyte> f)
            => a => f((sbyte)a);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate8 predicate(UnaryPredicate<byte> f)
            => a => f((byte)a);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate16 predicate(UnaryPredicate<short> f)
            => a => f((short)a);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate16 predicate(UnaryPredicate<ushort> f)
            => a => f((ushort)a);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate32 predicate(UnaryPredicate<int> f)
            => a => f((int)a);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate32 predicate(UnaryPredicate<uint> f)
            => a => f((uint)a);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate64 predicate(UnaryPredicate<long> f)
            => a => f((long)a);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate64 predicate(UnaryPredicate<ulong> f)
            => a => f(a);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate1 predicate(BinaryPredicate<bit> f)
            => (a, b) => f(a, b);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate8 predicate(BinaryPredicate<sbyte> f)
            => (a, b) => f((sbyte)a, (sbyte)b);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate8 predicate(BinaryPredicate<byte> f)
            => (a, b) => f(a, b);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate16 predicate(BinaryPredicate<short> f)
            => (a, b) => f((short)a, (short)b);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate16 predicate(BinaryPredicate<ushort> f)
            => (a, b) => f(a, b);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate32 predicate(BinaryPredicate<int> f)
            => (a, b) => f((int)a, (int)b);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate32 predicate(BinaryPredicate<uint> f)
            => (a, b) => f(a, b);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate64 predicate(BinaryPredicate<long> f)
            => (a, b) => f((long)a, (long)b);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate64 predicate(BinaryPredicate<ulong> f)
            => (a, b) => f(a, b);
    }
}