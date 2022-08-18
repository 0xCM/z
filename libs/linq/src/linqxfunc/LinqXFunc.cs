//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq.Expressions;

    using static Root;

    [ApiHost(ApiNames.LinqXFunc, true)]
    public class LinqXFunc
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Creates a function expression for an emitter
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <typeparam name="X">The function argument type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static XFunc<X> f<X>(Func<X> f)
            => f;

        /// <summary>
        /// Creates a function expression over a function delegate of arity 1
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <typeparam name="X">The function argument type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        [MethodImpl(Inline)]
        public static XFunc<X,Y> f<X,Y>(Func<X,Y> f)
            => f;

        /// <summary>
        /// Creates a function expression over a function delegate of arity 2
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <typeparam name="X1">The type of the first argument</typeparam>
        /// <typeparam name="X2">The type of the second argument</typeparam>
        /// <typeparam name="R">The return type</typeparam>
        [MethodImpl(Inline)]
        public static XFunc<X1,X2,R> f<X1,X2,R>(Func<X1,X2,R> f)
            => f;

        /// <summary>
        /// Creates a function expression over a function delegate of arity 3
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <typeparam name="X1">The type of the first argument</typeparam>
        /// <typeparam name="X2">The type of the second argument</typeparam>
        /// <typeparam name="X3">The type of the third argument</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        [MethodImpl(Inline)]
        public static XFunc<X1,X2,X3,R> f<X1,X2,X3,R>(Func<X1,X2,X3,R> f)
            => f;

        /// <summary>
        /// Creates a function expression over an homogenous function delegate of arity 2
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <typeparam name="X">The operand type</typeparam>
        [MethodImpl(Inline)]
        public static XFunc<X,X,X> f<X>(Func<X,X,X> f)
            => f;

        /// <summary>
        /// Creates a function expression over an homogenous function delegate of arity 3
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <typeparam name="X">The operand type</typeparam>
        [MethodImpl(Inline)]
        public static XFunc<X,X,X,X> f<X>(Func<X,X,X,X> f)
            => f;

        /// <summary>
        /// Creates a linq expression over an emitter
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <typeparam name="X">The function operand type</typeparam>
        /// <typeparam name="R">The function return type</typeparam>
        [MethodImpl(Inline)]
        public static Expression<Func<X>> fx<X>(Func<X> f)
            => LinqXFunc.f(f);

        /// <summary>
        /// Creates a linq expression over a function delegate of arity 1
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <typeparam name="X">The function operand type</typeparam>
        /// <typeparam name="R">The function return type</typeparam>
        [MethodImpl(Inline)]
        public static Expression<Func<X,R>> fx<X,R>(Func<X,R> f)
            => LinqXFunc.f(f);

        /// <summary>
        /// Creates a linq expression over a function delegate of arity 2
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <typeparam name="X1">The type of the first operand</typeparam>
        /// <typeparam name="X2">The type of the second operand</typeparam>
        /// <typeparam name="R">The function return type</typeparam>
        [MethodImpl(Inline)]
        public static Expression<Func<X1,X2,R>> fx<X1,X2,R>(Func<X1,X2,R> f)
            => LinqXFunc.f(f);

        /// <summary>
        /// Creates a linq expression over a function delegate of arity 3
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <typeparam name="X1">The type of the first operand</typeparam>
        /// <typeparam name="X2">The type of the second operand</typeparam>
        /// <typeparam name="X3">The type of the third operand</typeparam>
        /// <typeparam name="Y">The function return type</typeparam>
        [MethodImpl(Inline)]
        public static Expression<Func<X1,X2,X3,R>> fx<X1,X2,X3,R>(Func<X1,X2,X3,R> f)
            => LinqXFunc.f(f);
    }
}