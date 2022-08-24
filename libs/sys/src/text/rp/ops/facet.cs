//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Formats the operands as a facet 'k:v'
        /// </summary>
        /// <param name="key">The facet key</param>
        /// <param name="value">The facet value</param>
        /// <typeparam name="K">The the type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static string facet<K,V>(K key, V value)
            => string.Format(Attrib, key, value);

        /// <summary>
        /// Formats the operands as a facet 'k:v' where k is padded to a specified width
        /// </summary>
        /// <param name="key">The facet key</param>
        /// <param name="value">The facet value</param>
        /// <param name="pad">The oriented padding width</param>
        /// <typeparam name="K">The the type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static string facet<K,V>(K key, V value, int pad)
            => string.Format(Attrib, string.Format(RP.pad(pad),key), value);
    }
}