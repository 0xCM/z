//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class LogicOps
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public Product<T> product<T>(params T[] src)
            where T : IExpr
                => new Product<T>(src);

        [MethodImpl(Inline)]
        public Sum<T> sum<T>(params T[] src)
            where T : IExpr
                => new Sum<T>(src);

        [MethodImpl(Inline)]
        public static Sop<T> sop<T>(params Product<T>[] src)
            where T : IExpr
                => new Sop<T>(src);

        public static Sum untype<T>(Sum<T> src)
            where T : IExpr
                => new Sum(src.Terms.MapArray(x => (IExpr)x));

        public static Product untype<T>(Product<T> src)
            where T : IExpr
                => new Product(src.Terms.MapArray(x => (IExpr)x));

        [MethodImpl(Inline), Op]
        public static Xor xor(IBooleanExpr a, IBooleanExpr b)
            => new Xor(a,b);

        [MethodImpl(Inline)]
        public static Not not(IBooleanExpr a)
            => new Not(a);

        [MethodImpl(Inline), Op]
        public static Impl impl(IBooleanExpr @if, IBooleanExpr then)
            => new Impl(@if, then);

        [MethodImpl(Inline), Op]
        public static And and(IBooleanExpr a, IBooleanExpr b)
            => new And(a,b);

        [MethodImpl(Inline), Op]
        public static Or or(IBooleanExpr a, IBooleanExpr b)
            => new Or(a,b);
    }
}