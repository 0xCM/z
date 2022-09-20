//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class LookupProjector<K,V,T>
    {
        readonly ConcurrentDictionary<K,V> Values;

        readonly IProjector<V,T> Projector;

        public LookupProjector(IDictionary<K,V> src, IProjector<V,T> projector)
        {
            Values = new ConcurrentDictionary<K,V>(src);
            Projector = projector;
        }

        public LookupProjector(ConcurrentDictionary<K,V> src, IProjector<V,T> projector)
        {
            Values = src;
            Projector = projector;
        }

        [MethodImpl(Inline)]
        public bool Find(K key, out V value)
            => Values.TryGetValue(key, out value);

        [MethodImpl(Inline)]
        public bool Map(K key, out T output)
        {
            if(Find(key, out V value))
            {
                output = Projector.Invoke(value);
                return true;
            }
            else
            {
                output = default;
                return false;
            }
        }

        [MethodImpl(Inline)]
        public T Map(K key)
            => Projector.Invoke(Values[key]);
    }
}