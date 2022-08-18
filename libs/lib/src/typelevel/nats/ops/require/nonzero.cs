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
        /// Attempts to prove that k:K => k != 0
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <typeparam name="K">A nonzero natural type</typeparam>
        [MethodImpl(Inline)]
        public static NatNonzero<K> nonzero<K>()
            where K: unmanaged, ITypeNat
                => new NatNonzero<K>(natrep<K>());

        /// <summary>
        /// Attempts to prove that k:K => k != 0
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <typeparam name="K">A nonzero natural type</typeparam>
        [MethodImpl(Inline)]
        public static NatNonzero<K> nonzero<K>(K k)
            where K: unmanaged, ITypeNat
                => new NatNonzero<K>(k);
    }
}