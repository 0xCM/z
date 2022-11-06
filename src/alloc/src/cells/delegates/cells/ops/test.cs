//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CellDelegates
    {
        [MethodImpl(Inline), Op]
        public static bit test(UnaryPredicate8 f, Cell8 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static bit test(UnaryPredicate16 f, Cell16 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static bit test(UnaryPredicate32 f, Cell32 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static bit test(UnaryPredicate64 f, Cell64 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static bit test(UnaryPredicate128 f, Cell128 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static bit test(UnaryPredicate256 f, Cell256 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static bit test(UnaryPredicate512 f, Cell512 a)
            => f(a);

        [MethodImpl(Inline), Op]
        public static bit test(BinaryPredicate8 f, Cell8 a, Cell8 b)
            => f(a,b);

        [MethodImpl(Inline), Op]
        public static bit test(BinaryPredicate16 f, Cell16 a, Cell16 b)
            => f(a,b);

        [MethodImpl(Inline), Op]
        public static bit test(BinaryPredicate32 f, Cell32 a, Cell32 b)
            => f(a,b);

        [MethodImpl(Inline), Op]
        public static bit test(BinaryPredicate64 f, Cell64 a, Cell64 b)
            => f(a,b);

        [MethodImpl(Inline), Op]
        public static bit test(BinaryPredicate128 f, Cell128 a, Cell128 b)
            => f(a,b);

        [MethodImpl(Inline), Op]
        public static bit test(BinaryPredicate256 f, Cell256 a, Cell256 b)
            => f(a,b);

        [MethodImpl(Inline), Op]
        public static bit test(BinaryPredicate512 f, Cell512 a, Cell512 b)
            => f(a,b);
    }
}