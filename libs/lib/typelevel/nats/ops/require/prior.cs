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
        /// Attempts to prove that k:K1 & k:K2 => k1 = k2 + 1
        /// Signals success by returning true
        /// Signals failure by either returning false or raising an error
        /// </summary>
        /// <param name="raise">Specifies whether an error should be raised if the check fails</param>
        /// <typeparam name="K1">The next type</typeparam>
        /// <typeparam name="K2">The prior</typeparam>
        [MethodImpl(Inline)]
        public static bool successor<K1,K2>(bool raise = true)
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
                =>  value<K1>() == value<K2>() + 1 ? true : failure<K1,K2>(nameof(successor), raise);

        /// <summary>
        /// Attempts construct evidence that k1 = k2 + 1;
        /// </summary>
        /// <typeparam name="K1">The source type</typeparam>
        /// <typeparam name="K2">The successor type</typeparam>
        [MethodImpl(Inline)]
        public static NatPrior<K1,K2> prior<K1,K2>(K1 k1 = default, K2 k2 = default)
            where K1: unmanaged, ITypeNat
            where K2: unmanaged, ITypeNat
                => new NatPrior<K1,K2>(k1,k2);
    }
}