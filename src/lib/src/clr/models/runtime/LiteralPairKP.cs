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
    /// Defines an identifiable association between two homogenous literal values
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="P">The first literal type</typeparam>
    public readonly struct LiteralPair<K,P>
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
        public readonly P Second;

        [MethodImpl(Inline)]
        public LiteralPair(K key, P first, P second)
        {
            Key = key;
            First = first;
            Second = second;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out P first, out P second)
        {
            first = First;
            second = Second;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RpOps.Tuple3, Key, First, Second);


        [MethodImpl(Inline)]
        public static implicit operator LiteralPair<K,P>((K key, P first, P second) src)
            => new LiteralPair<K,P>(src.key,src.first,src.second);

        [MethodImpl(Inline)]
        public static implicit operator LiteralPair<K,P,P>(LiteralPair<K,P> src)
            => new LiteralPair<K,P,P>(src.Key, src.First, src.Second);
    }
}