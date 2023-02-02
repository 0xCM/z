//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static TypedLogicSpec;

    using TLS = TypedLogicSpec;

    [ApiHost]
    public static class TypedIdentities
    {
        const NumericKind Closure = UInt64k;

        public static Index<ComparisonExpr<T>> ScalarIdentities<T>()
            where T : unmanaged
                => array(AndOverOr<T>(), AndOverXOr<T>(), OrOverAnd<T>(), NotOverAnd<T>(), NotOverXOr<T>());

        public static Index<ComparisonExpr<Vector128<T>>> Vec128Identities<T>()
            where T : unmanaged
                => array(AndOverOr128<T>(), AndOverXOr128<T>(), OrOverAnd128<T>(), NotOverAnd128<T>(), NotOverXOr128<T>());

        public static Index<ComparisonExpr<Vector256<T>>> Vec256Identities<T>()
            where T : unmanaged
                => array(AndOverOr256<T>(), AndOverXOr256<T>(), OrOverAnd256<T>(), NotOverAnd256<T>(), NotOverXOr256<T>());

        /// <summary>
        /// Specifies the identity and(a,or(b,c)) == or(and(a,b), and(a,c))
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> AndOverOr<T>()
            where T : unmanaged
        {
            (var a, var b, var c) = vars3<T>();
            var lhs = and(a, or(b,c));
            var rhs = or(and(a,b), and(a,c));
            return equals(lhs, rhs, a,b,c);
        }

        /// <summary>
        /// Specifies the identity and(a,xor(b,c)) == xor(and(a,b), and(a,c))
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> AndOverXOr<T>()
            where T : unmanaged
        {
            (var a, var b, var c) = vars3<T>();
            var lhs = and(a, xor(b,c));
            var rhs = xor(and(a,b), and(a,c));
            return equals(lhs,rhs, a,b,c);
        }

        /// <summary>
        /// Specifies the identity or(a,and(b,c)) == and(or(a,b), or(a,c))
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> OrOverAnd<T>()
            where T : unmanaged
        {
            (var a, var b, var c) = vars3<T>();
            var lhs = and(a, or(b,c));
            var rhs = or(and(a,b), and(a,c));
            return equals(lhs, rhs, a, b, c);
        }

        /// <summary>
        /// Specifies the identity not(and(a,b)) == or(not(x),not(y))
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> NotOverAnd<T>()
            where T : unmanaged
        {
            (var a, var b) = vars2<T>();
            var lhs = not(and(a,b));
            var rhs = or(not(a), not(b));
            return equals(lhs,rhs,a,b);
        }

        /// <summary>
        /// Specifies the identity not(xor(a,b)) == xor(not(x),y)
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> NotOverXOr<T>()
            where T : unmanaged
        {
            (var a, var b) = vars2<T>();
            var lhs = not(xor(a,b));
            var rhs = xor(not(a),b);
            return equals(lhs,rhs,a,b);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<Vector128<T>> AndOverOr128<T>()
            where T : unmanaged
                => AndOverOr<Vector128<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<Vector128<T>> AndOverXOr128<T>()
            where T : unmanaged
                => AndOverXOr<Vector128<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<Vector128<T>> OrOverAnd128<T>()
            where T : unmanaged
                => OrOverAnd<Vector128<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<Vector128<T>> NotOverAnd128<T>()
            where T : unmanaged
                => NotOverAnd<Vector128<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<Vector128<T>> NotOverXOr128<T>()
            where T : unmanaged
                => NotOverXOr<Vector128<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<Vector256<T>> AndOverOr256<T>()
            where T : unmanaged
                => AndOverOr<Vector256<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<Vector256<T>> AndOverXOr256<T>()
            where T : unmanaged
                => AndOverXOr<Vector256<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<Vector256<T>> OrOverAnd256<T>()
            where T : unmanaged
                => OrOverAnd<Vector256<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<Vector256<T>> NotOverAnd256<T>()
            where T : unmanaged
                => NotOverAnd<Vector256<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<Vector256<T>> NotOverXOr256<T>()
            where T : unmanaged
                => NotOverXOr<Vector256<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        static (ILogixVarExpr<T> a, ILogixVarExpr<T> b) vars2<T>()
            where T : unmanaged
                => (TLS.variable<T>('a'), TLS.variable<T>('b'));

        [MethodImpl(Inline), Op, Closures(Closure)]
        static (ILogixVarExpr<T> a, ILogixVarExpr<T> b, ILogixVarExpr<T> c) vars3<T>()
            where T : unmanaged
                => (TLS.variable<T>('a'), TLS.variable<T>('b'), TLS.variable<T>('c'));
    }
}