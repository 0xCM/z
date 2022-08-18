//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a reference to a value
    /// </summary>
    public readonly struct Ref<K,V> : IValueRef<V>
        where V : IRefResolver<K,V>
        where K : unmanaged
    {
        readonly V Resolver;

        readonly K Key;

        [MethodImpl(Inline)]
        public Ref(K key, V resolver)
        {
            Key = key;
            Resolver = resolver;
        }

        public ref V Value
        {
            [MethodImpl(Inline)]
            get => ref Resolver.Resolve(Key);
        }

        [MethodImpl(Inline)]
        public static implicit operator Ref<K,V>((K key, V resolver) src)
            => new Ref<K,V>(src.key, src.resolver);
    }
}