//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct Enums
    {
        /// <summary>
        /// Constructs a arbitrarily deduplicated value-to-member index
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="V">The numeric value type</typeparam>
        public static IDictionary<V,E> dictionary<E,V>()
            where E : unmanaged, Enum
            where V : unmanaged
        {
            var pairs = Enums.details<E,V>();
            var index = new Dictionary<V,E>();
            foreach(var pair in pairs)
                index.TryAdd(pair.PrimalValue, pair.LiteralValue);
            return index;
        }
    }
}