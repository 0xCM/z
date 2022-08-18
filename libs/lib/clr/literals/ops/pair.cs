//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrLiterals
    {
        /// <summary>
        /// Defines an homogenous pair of key-correlated literals
        /// </summary>
        /// <param name="key">The correlation key</param>
        /// <param name="first">The fist member</param>
        /// <param name="second">The second member</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="P">The literal type</typeparam>
        [MethodImpl(Inline)]
        public static LiteralPair<K,P> pair<K,P>(K key, P first, P second)
            => new LiteralPair<K,P>(key, first, second);

        /// <summary>
        /// Defines a heterogenous pair of key-correlated literals
        /// </summary>
        /// <param name="key">The correlation key</param>
        /// <param name="first">The fist literal</param>
        /// <param name="second">The second literal</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="P">The first literal type</typeparam>
        /// <typeparam name="Q">The second literal type</typeparam>
        [MethodImpl(Inline)]
        public static LiteralPair<K,P,Q> pair<K,P,Q>(K key, P first, Q second)
            => new LiteralPair<K,P,Q>(key, first, second);
    }
}