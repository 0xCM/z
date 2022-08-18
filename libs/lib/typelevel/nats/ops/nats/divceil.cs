//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class NatCalc
    {
        /// <summary>
        /// Computes the upward-rounded quotient
        /// q := natval[N] % bitsize[T] == 0 ? natval[N] / bitsize[T] : (natval[N] / bitsize[T]) + 1
        /// </summary>
        /// <param name="n">The natural representative</param>
        /// <param name="t">A type representative</param>
        /// <typeparam name="N">The natural type</typeparam>
        /// <typeparam name="T">The width type</typeparam>
        [MethodImpl(Inline)]
        public static ulong divceilT<N,T>(N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => modT(n,t) == 0ul ? divT(n,t) : divT(n,t) + 1ul;
    }
}