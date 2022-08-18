//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a reference to a value
    /// </summary>
    public readonly struct ConstRef<K,V> : IConstRef<V>
        where V : IConstRefResolver<K,V>
        where K : unmanaged
    {
        readonly V Resolver;

        readonly K Key;

        [MethodImpl(Inline)]
        public ConstRef(K key, V resolver)
        {
            Key = key;
            Resolver = resolver;
        }

        public ref readonly V Value
        {
            [MethodImpl(Inline)]
            get => ref Resolver.Resolve(Key);
        }

        [MethodImpl(Inline)]
        public static implicit operator ConstRef<K,V>((K key, V resolver) src)
            => new ConstRef<K,V>(src.key, src.resolver);
    }
}