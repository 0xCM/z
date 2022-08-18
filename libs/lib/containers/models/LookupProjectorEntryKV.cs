//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LookupProjectorEntry<K,V,T>
    {
        public readonly K Key;

        public readonly V Value;

        internal readonly IProjector<V,T> Projector;

        [MethodImpl(Inline)]
        public LookupProjectorEntry(K key, V value, IProjector<V,T> projector)
        {
            Key = key;
            Value = value;
            Projector = projector;
        }

        [MethodImpl(Inline)]
        public T Project()
            => Projector.Invoke(Value);

        [MethodImpl(Inline)]
        public static implicit operator LookupProjectorEntry<K,V,T>((K key, V value, IProjector<V,T> projector) src)
            => new LookupProjectorEntry<K,V,T>(src.key, src.value, src.projector);
    }
}