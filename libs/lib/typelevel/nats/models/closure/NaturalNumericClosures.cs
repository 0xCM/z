//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    public class NaturalNumericClosures
    {
        /// <summary>
        /// Defines an untyped closure over a natural numeric method of sort NxT or MxNxT
        /// </summary>
        /// <param name="def">A generic method definition that requires either arguments M, and T
        /// in that order or, alternately, M, N and T in that order</param>
        /// <param name="m">The M-natural kind, if present</param>
        /// <param name="n">The N-natural kind</param>
        /// <param name="t">The T-numeric kind</param>
        [MethodImpl(Inline)]
        public static NaturalNumericClosure Define(MethodInfo def, ulong? m, ulong n, NumericKind t)
            => new NaturalNumericClosure(def,m,n,t);

        /// <summary>
        /// Defines a T-parametric closure that includes either one or two natural parameter specifications
        /// </summary>
        /// <param name="def">A generic method definition that requires either arguments M, and T
        /// in that order or, alternately, M, N and T in that order</param>
        /// <typeparam name="N">An intrinsic natural type</typeparam>
        /// <typeparam name="T">A numeric type</typeparam>
        [MethodImpl(Inline)]
        public static NaturalNumericClosure<T> Define<T>(MethodInfo def, ulong? m, ulong n)
            where T : unmanaged
                => new NaturalNumericClosure<T>(def,m,n);

        /// <summary>
        /// Defines a closure pair NxT over a conforming generic method definition
        /// </summary>
        /// <param name="def">A generic method definition that requires arguments M, and T, in that order</param>
        /// <typeparam name="N">An intrinsic natural type</typeparam>
        /// <typeparam name="T">A numeric type</typeparam>
        [MethodImpl(Inline)]
        public static NaturalNumericClosure<N,T> Define<N,T>(MethodInfo def)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new NaturalNumericClosure<N,T>(def);

        /// <summary>
        /// Defines a closure triple MxNxT over a conforming generic method definition
        /// </summary>
        /// <param name="def">A generic method definition that requires arguments M, N, and T, in that order</param>
        /// <typeparam name="M">An intrinsic natural type</typeparam>
        /// <typeparam name="N">An intrinsic natural type</typeparam>
        /// <typeparam name="T">A numeric type</typeparam>
        [MethodImpl(Inline)]
        public static NaturalNumericClosure<M,N,T> Define<M,N,T>(MethodInfo def)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new NaturalNumericClosure<M,N,T>(def);
    }
}