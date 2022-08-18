//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an identifiable association between two heterogenous literal values
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="P">The first literal type</typeparam>
    /// <typeparam name="Q">The second literal type</typeparam>
    public readonly struct LiteralPair<K,P,Q>
    {
        /// <summary>
        /// The identifying key
        /// </summary>
        public readonly K Key;

        /// <summary>
        /// The first literal value
        /// </summary>
        public readonly P First;

        /// <summary>
        /// The second literal value
        /// </summary>
        public readonly Q Second;

        [MethodImpl(Inline)]
        public static implicit operator LiteralPair<K,P,Q>((K key, P first, Q second) src)
            => new LiteralPair<K,P,Q>(src.key,src.first,src.second);

        [MethodImpl(Inline)]
        public LiteralPair(K key, P first, Q second)
        {
            Key = key;
            First = first;
            Second = second;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out P first, out Q second)
        {
            first = First;
            second = Second;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RpOps.Tuple3, Key, First, Second);
    }
}