//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        /// <summary>
        /// Constructs a <see cref='Z0.Pairings{K,V}'/> from a dictionary
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static Pairings<K,V> Pairings<K,V>(this IDictionary<K,V> src)
        {
            var count = src.Count;
            var dst = alloc<Paired<K,V>>(count);
            var keys = src.Keys.Index();
            for(var i=0; i<count; i++)
                seek(dst,i) = (keys[i], src[keys[i]]);
            return dst;
        }
    }
}