//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a reference to a value
    /// </summary>
    public readonly struct ConstRef<V> : IConstRef<V>
        where V : IConstRefResolver<V>
    {
        readonly V Resolver;

        readonly uint Key;

        [MethodImpl(Inline)]
        public ConstRef(uint key, V resolver)
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
        public static implicit operator ConstRef<V>((uint key, V resolver) src)
            => new ConstRef<V>(src.key, src.resolver);
    }
}