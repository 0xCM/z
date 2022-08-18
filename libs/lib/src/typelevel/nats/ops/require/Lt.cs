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

    partial class NatRequire
    {
        /// <summary>
        /// Attempts to prove k < a
        /// Signals success by returning true
        /// Signals failure by raising an error
        /// </summary>
        /// <param name="k">The natural value</param>
        /// <param name="a">The value to test</param>
        /// <typeparam name="K">The natural representative</typeparam>
        [MethodImpl(Inline)]
        public static bool lt<K>(K k, ulong a)
            where K : unmanaged, ITypeNat
                =>  value<K>() < a ? true : failure<K>("lt", a);

        /// <summary>
        /// Attempts to prove k <= a
        /// Signals success by returning true
        /// Signals failure by raising an error
        /// </summary>
        /// <param name="k">The natural value</param>
        /// <param name="t">The value to test</param>
        /// <typeparam name="K">The natural representative</typeparam>
        [MethodImpl(Inline)]
        public static bool lteq<K>(K k, ulong t)
            where K : unmanaged, ITypeNat
                =>  value<K>() <= t ? true : failure<K>("lteq", t);

        /// <summary>
        /// Attempts to construct evidence that k1 < k2
        /// </summary>
        /// <typeparam name="K1">The smaller type</typeparam>
        /// <typeparam name="K2">The larger type</typeparam>
        [MethodImpl(Inline)]
        public static NatLt<K1,K2> lt<K1,K2>(K1 k1 = default, K2 k2 = default)
            where K1: unmanaged, ITypeNat
            where K2: unmanaged, ITypeNat
                => new NatLt<K1,K2>(k1,k2);
    }
}