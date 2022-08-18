//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class NatRequire
    {
        /// <summary>
        /// Attempts to prove k1 * k2 = expected
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <typeparam name="K1">The first type</typeparam>
        /// <typeparam name="K2">The second type</typeparam>
        public static NatMul<K1,K2> mul<K1,K2>(uint expected)
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
        {
            eq<NatMul<K1,K2>>(expected);
            return product<K1,K2>();
        }

        /// <summary>
        /// Attempts to prove k1 * k2 = expected
        /// Signals success by returning evidence
        /// Signals failure by raising an error
        /// </summary>
        /// <param name="k1">The first operand value</param>
        /// <param name="k2">The second operand value</param>
        /// <typeparam name="K1">The first type</typeparam>
        /// <typeparam name="K2">The second type</typeparam>
        public static NatMul<K1,K2> mul<K1,K2>(K1 k1, K2 k2, uint expected)
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
        {
            eq<NatMul<K1,K2>>(expected);
            return product<K1,K2>();
        }

        /// <summary>
        /// Constructs a natural representative that encodes the product of two naturals
        /// </summary>
        /// <typeparam name="K1">The first operand type</typeparam>
        /// <typeparam name="K2">The second operand type</typeparam>
        [MethodImpl(Inline)]
        static NatMul<K1,K2> product<K1,K2>(K1 k1 = default, K2 k2 = default)
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
                => NatMul<K1,K2>.Rep;
    }
}