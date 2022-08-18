//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static TypeNats;
    using static Root;

    partial class NatRequire
    {
        /// <summary>
        /// If possible, constructs evidence that k1:K1 & k2:K2 => k1 + 1 = k2; otherwise raises an error
        /// </summary>
        /// <typeparam name="K1">The source type</typeparam>
        /// <typeparam name="K2">The successor type</typeparam>
        [MethodImpl(Inline)]
        public static NatNext<K1,K2> next<K1,K2>()
            where K1: unmanaged, ITypeNat
            where K2: unmanaged, ITypeNat
                => new NatNext<K1,K2>(natrep<K1>(),natrep<K2>());

        /// <summary>
        /// If possible, constructs evidence that k1:K1 & k2:K2 => k1 + 1 = k2; otherwise raises an error
        /// </summary>
        /// <typeparam name="K1">The source type</typeparam>
        /// <typeparam name="K2">The successor type</typeparam>
        [MethodImpl(Inline)]
        public static NatNext<K1,K2> next<K1,K2>(K1 k1, K2 k2)
            where K1: unmanaged, ITypeNat
            where K2: unmanaged, ITypeNat
                => new NatNext<K1,K2>(k1,k2);
    }
}