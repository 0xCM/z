//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a reference to a value
    /// </summary>
    public readonly struct Ref<V> : IValueRef<V>
        where V : IRefResolver<V>
    {
        readonly V Resolver;

        readonly uint Key;

        [MethodImpl(Inline)]
        public Ref(uint key, V resolver)
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
        public static implicit operator Ref<V>((uint key, V resolver) src)
            => new Ref<V>(src.key, src.resolver);
    }
}