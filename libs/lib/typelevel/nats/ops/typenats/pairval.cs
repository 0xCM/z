//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class TypeNats
    {
        /// <summary>
        /// Constructs (k1,k2) where k1:K2 & k2:K2
        /// </summary>
        /// <typeparam name="K1">The first nat type</typeparam>
        /// <typeparam name="K2">The second type</typeparam>
        [MethodImpl(Inline)]
        public static (ulong k1, ulong k2) pairval<K1,K2>(K1 k1 = default, K2 k2 = default)
            where K2 : unmanaged, ITypeNat
            where K1 : unmanaged, ITypeNat
                => (value<K1>(), value<K2>());
    }
}