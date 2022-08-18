//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Initializes an empty dictionary
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The vale type</typeparam>
        [MethodImpl(Inline)]
        public static Dictionary<K,V> dict<K,V>()
            => new Dictionary<K,V>();

        /// <summary>
        /// Initializes an empty condurrent dictionary
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The vale type</typeparam>
        [MethodImpl(Inline)]
        public static ConcurrentDictionary<K,V> cdict<K,V>()
            => new();

        /// <summary>
        /// Initializes an empty dictionary with a specified capacity
        /// </summary>
        /// <param name="capacity">The initial capacity</param>
        /// <param name="kRep">A key representative used only for type inference</param>
        /// <param name="vRep">A value representative used only for type inference</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The vale type</typeparam>
        [MethodImpl(Inline)]
        public static Dictionary<K,V> dict<K,V>(uint capacity)
            => new((int)capacity);

        /// <summary>
        /// Initializes an empty dictionary with a specified capacity
        /// </summary>
        /// <param name="capacity">The initial capacity</param>
        /// <param name="kRep">A key representative used only for type inference</param>
        /// <param name="vRep">A value representative used only for type inference</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The vale type</typeparam>
        [MethodImpl(Inline)]
        public static Dictionary<K,V> dict<K,V>(int capacity)
            => new(capacity);
    }
}