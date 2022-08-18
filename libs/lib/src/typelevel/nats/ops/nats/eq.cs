//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static TypeNats;

    partial class NatCalc
    {
        [MethodImpl(Inline)]
        public static bool eq<K1,K2>(K1 k1 = default, K2 k2 = default)
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
                => value(k1) == value(k2);

        /// <summary>
        /// Computes the predicate p := natval[N] == bitsize[T]
        /// </summary>
        /// <param name="n">The natural representative</param>
        /// <param name="t">A type representative</param>
        /// <typeparam name="N">The natural type</typeparam>
        /// <typeparam name="T">The bit width type</typeparam>
        [MethodImpl(Inline)]
        public static bool eqT<N,T>(N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => value<N>() == bitcount<T>();
    }
}