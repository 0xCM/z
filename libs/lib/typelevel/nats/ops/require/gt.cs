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
        /// Attempts to prove k > a
        /// Signals success by returning true
        /// Signals failure by raising an error
        /// </summary>
        /// <param name="a">The value to test</param>
        /// <typeparam name="K">The natural representative</typeparam>
        [MethodImpl(Inline)]
        public static bool gt<K>(K k, ulong a)
            where K : unmanaged, ITypeNat
                =>  value<K>() > a ? true : failure<K>("gt", a);

        /// <summary>
        /// Attempts to prove k >= a
        /// Signals success by returning true
        /// Signals failure by raising an error
        /// </summary>
        /// <param name="t">The value to test</param>
        /// <typeparam name="K">The natural representative</typeparam>
        [MethodImpl(Inline)]
        public static bool gteq<K>(K k, ulong a)
            where K : unmanaged, ITypeNat
                =>  value<K>() >= a ? true : failure<K>("gteq", a);

        /// <summary>
        /// Attempts to prove k1 > k2
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <typeparam name="K1">The larger type</typeparam>
        /// <typeparam name="K2">The smaller type</typeparam>
        [MethodImpl(Inline)]
        public static NatGt<K1,K2> gt<K1,K2>(K1 k1 = default, K2 k2 = default)
            where K1: unmanaged, ITypeNat
            where K2: unmanaged, ITypeNat
                => new NatGt<K1,K2>(k1,k2);
    }
}