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
        /// Attempts to prove that k1:K1 & k2:K2 & k3:K3 => k1 % k2 = k3
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <typeparam name="K1">The first natural type</typeparam>
        /// <typeparam name="K2">The second natural type</typeparam>
        /// <typeparam name="K3">The third natural type</typeparam>
        [MethodImpl(Inline)]
        public static NatMod<K1,K2,K3> mod<K1,K2,K3>()
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
            where K3 : unmanaged, ITypeNat
                => new NatMod<K1,K2,K3>(natrep<K1>(), natrep<K2>(),natrep<K3>());

        /// <summary>
        /// Attempts to prove that k1:K1 & k2:K2 & k3:K3 => k1 % k2 = k3
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <typeparam name="K1">The first natural type</typeparam>
        /// <typeparam name="K2">The second natural type</typeparam>
        /// <typeparam name="K3">The third natural type</typeparam>
        [MethodImpl(Inline)]
        public static NatMod<K1,K2,K3> mod<K1,K2,K3>(K1 k1, K2 k2, K3 k3)
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
            where K3 : unmanaged, ITypeNat
                => new NatMod<K1,K2,K3>(k1, k2, k3);

        /// <summary>
        /// Attempts to prove that k:K1 => k % 2 == 0
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <typeparam name="K">An even natural type</typeparam>
        [MethodImpl(Inline)]
        public static NatEven<K> even<K>()
            where K: unmanaged, ITypeNat
                => new NatEven<K>(natrep<K>());

        /// <summary>
        /// Attempts to prove that k:K1 => k % 2 == 0
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <typeparam name="K">An even natural type</typeparam>
        [MethodImpl(Inline)]
        public static NatEven<K> even<K>(K k)
            where K: unmanaged, ITypeNat
                => new NatEven<K>(k);

        /// <summary>
        /// Attempts to prove that k:K1 => k % 2 != 0
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <typeparam name="K">An odd natural type</typeparam>
        [MethodImpl(Inline)]
        public static NatOdd<K> odd<K>()
            where K: unmanaged, ITypeNat
                => new NatOdd<K>(natrep<K>());

        /// <summary>
        /// Attempts to prove that k:K1 => k % 2 != 0
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <typeparam name="K">An odd natural type</typeparam>
        [MethodImpl(Inline)]
        public static NatOdd<K> odd<K>(K k)
            where K: unmanaged, ITypeNat
                => new NatOdd<K>(k);
    }
}