//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static TypeNats;

    partial class NatRequire
    {
       /// <summary>
        /// If possible, constructs evidence that n:K => n prime; otherwise,
        /// raises an error
        /// </summary>
        /// <typeparam name="K">The subject</typeparam>
        public static NatPrime<K> prime<K>()
            where K: unmanaged, ITypeNat
                => new NatPrime<K>(natrep<K>());

        /// <summary>
        /// If possible, constructs evidence that n:K => n prime; otherwise,
        /// raises an error
        /// </summary>
        /// <typeparam name="K">The subject</typeparam>
        public static NatPrime<K> prime<K>(K k)
            where K: unmanaged, ITypeNat
                => new NatPrime<K>(k);
    }
}