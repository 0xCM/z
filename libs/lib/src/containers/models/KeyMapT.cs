//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = LookupTables;

    /// <summary>
    /// Associates a <see cref='LoookupKey'/> with a <typeparamref name='T'/> value
    /// </summary>
    public readonly struct KeyMap<T> : ITextual
    {
        public LookupKey Key {get;}

        public T Target {get;}

        [MethodImpl(Inline)]
        public KeyMap(LookupKey key, T target)
        {
            Key = key;
            Target = target;
        }

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator KeyMap<T>((LookupKey key, T target) src)
            => new KeyMap<T>(src.key, src.target);
    }
}