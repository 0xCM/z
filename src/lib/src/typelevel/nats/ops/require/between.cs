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
        /// Attempts to prove that that n:K & n1:K1 & n2:K2 => n1 <= n <= n2
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <typeparam name="K">The subject</typeparam>
        /// <typeparam name="K1">The lower inclusive bound</typeparam>
        /// <typeparam name="K2">The upper inclusive bound</typeparam>
        [MethodImpl(Inline)]
        public static NatBetween<K,K1,K2> between<K,K1,K2>()
            where K: unmanaged, ITypeNat
            where K1: unmanaged, ITypeNat
            where K2: unmanaged, ITypeNat
                => new NatBetween<K,K1,K2>(natrep<K>(), natrep<K1>(), natrep<K2>());

        /// <summary>
        /// Attempts to prove that that n:K & n1:K1 & n2:K2 => n1 <= n <= n2
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <typeparam name="K">The subject</typeparam>
        /// <typeparam name="K1">The lower inclusive bound</typeparam>
        /// <typeparam name="K2">The upper inclusive bound</typeparam>
        [MethodImpl(Inline)]
        public static NatBetween<K,K1,K2> between<K,K1,K2>(K k, K1 k1, K2 k2)
            where K: unmanaged, ITypeNat
            where K1: unmanaged, ITypeNat
            where K2: unmanaged, ITypeNat
                => new NatBetween<K,K1,K2>(k, k1, k2);

    }
}