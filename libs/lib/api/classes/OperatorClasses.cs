//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiClasses;

    [ApiHost]
    public readonly struct OperatorClasses
    {
        const NumericKind Closure = NumericKind.UnsignedInts;

        public static EmitterClass emitter()
            => default;

        public static EmitterClass<T> emitter<T>(T t = default)
            where T : unmanaged => default;

        public static ReceiverClass<T> receiver<T>()
            where T : unmanaged => default;

        public static UnaryOperatorClass unary()
            => default;

        public static UnaryOperatorClass<T> unary<T>(T t = default)
            where T : unmanaged => default;

        public static BinaryOperatorClass binary()
            => default;

        public static BinaryOperatorClass<T> binary<T>(T t = default)
            where T : unmanaged => default;

        public static TernaryOperatorClass ternary()
            => default;

        public static TernaryOperatorClass<T> ternary<T>(T t = default)
            where T : unmanaged => default;

        public static ShiftOperatorClass shift()
            => default;

        public static UnaryPredicate predicate(N1 n)
            => default;

        public static BinaryPredicate predicate(N2 n)
            => default;

        public static TernaryPredicate predicate(N3 n)
            => default;

        [KindFactory]
        public static UnaryActionClass action(N1 n)
            => default;

        [KindFactory]
        public static BinaryActionClass action(N2 n)
            => default;

        [KindFactory]
        public static TernaryActionClass action(N3 n)
            => default;

        public static EmitterFunc func(N0 n)
            => default;

        public static UnaryFunc func(N1 n)
            => default;

        public static BinaryFunc func(N2 n)
            => default;

        public static TernaryFunc func(N3 rep)
            => default;

        public static UnaryFunc<A,R> func<A,R>(A a = default, R r = default)
            => default;

        public static BinaryFunc<A,B,R> func<A,B,R>(A a = default, B b = default, R r = default)
            => default;

        public static TernaryFunc<A,B,C,R> func<A,B,C,R>(A a = default, B b = default, C c = default, R r = default)
            => default;
    }
}