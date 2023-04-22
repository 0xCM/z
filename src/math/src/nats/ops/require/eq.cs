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
        /// Retrieves the value of the natural number associated with a typenat
        /// and returns the value if it agrees with a supplied expected value; otherwise,
        /// raises an exception
        /// </summary>
        /// <param name="expected">The expected natural value</param>
        /// <typeparam name="K">The natural type</typeparam>
        [MethodImpl(Inline)]
        public static ulong eq<K>(ulong expected)
            where K : unmanaged, ITypeNat
                => value<K>() == expected  ? expected : failure<K,ulong>("eq", expected);

        /// <summary>
        /// Retrieves the value of the natural number associated with a typenat
        /// and returns the value if it agrees with a supplied expected value; othwise,
        /// raises an exception
        /// </summary>
        /// <param name="k">The reification of K</param>
        /// <param name="expected">The expected natural value</param>
        /// <typeparam name="K">The natural type</typeparam>
        [MethodImpl(Inline)]
        public static ulong eq<K>(K k, ulong expected)
            where K : unmanaged, ITypeNat
                => k.NatValue == expected  ? expected : failure<K,ulong>("eq", expected);

        /// <summary>
        /// Attempts to prove that k:K => k == expected
        /// Registers success by returning the expected value
        /// Registers failure by raising an error
        /// </summary>
        /// <param name="expected">The expected natural value</param>
        /// <typeparam name="K">The natural type</typeparam>
        [MethodImpl(Inline)]
        public static uint eq<K>(int expected)
            where K : unmanaged, ITypeNat
                => value<K>() == (uint)expected ? (uint)expected : failure<K,uint>("eq", (uint)expected);

        /// <summary>
        /// Attempts to prove that k:K => k == expected
        /// Registers success by returning the expected value
        /// Registers failure by raising an error
        /// </summary>
        /// <param name="k">The reification of K</param>
        /// <param name="expected">The expected natural value</param>
        /// <typeparam name="K">The natural type</typeparam>
        [MethodImpl(Inline)]
        public static uint eq<K>(K k, int expected)
            where K : unmanaged, ITypeNat
                => value<K>() == (uint)expected ? (uint)expected : failure<K,uint>("eq", (uint)expected);

        /// <summary>
        /// Prooves that a test value is equal to the value of a natural representative
        /// </summary>
        /// <param name="test">The value to test</param>
        /// <param name="raise">Specifies whether an error should be raised if the check fails</param>
        /// <typeparam name="K">The natural representative</typeparam>
        [MethodImpl(Inline)]
        public static bool eq<K>(uint test, bool raise = true)
            where K : unmanaged, ITypeNat
                => value<K>() == test ? true : failure<K>("eq", test, raise);

        /// <summary>
        /// Attemts to construct evidence that k1 == k2
        /// </summary>
        /// <typeparam name="K1">The first type</typeparam>
        /// <typeparam name="K2">The second type</typeparam>
        [MethodImpl(Inline)]
        public static NatEq<K1,K2> eq<K1,K2>(K1 k1 = default, K2 k2 = default)
            where K1: unmanaged, ITypeNat
            where K2: unmanaged, ITypeNat
                => new NatEq<K1,K2>(k1,k2);

        /// <summary>
        /// Attemts to construct evidence that k1 != k2
        /// </summary>
        /// <typeparam name="K1">The first type</typeparam>
        /// <typeparam name="K2">The second type</typeparam>
        [MethodImpl(Inline)]
        public static NatNEq<K1,K2> neq<K1,K2>(K1 k1 = default, K2 k2 = default)
            where K1: unmanaged, ITypeNat
            where K2: unmanaged, ITypeNat
                => new NatNEq<K1,K2>(k1,k2);
    }
}