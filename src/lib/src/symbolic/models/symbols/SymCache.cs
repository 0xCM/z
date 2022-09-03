//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SymCache<K>
        where K : unmanaged, Enum
    {
        [MethodImpl(Inline)]
        internal static SymCache<K> get()
            => new SymCache<K>();

        static SymCache()
            => Storage = SymIndexBuilder.create<K>();

        public ref readonly Sym<K> this[K index]
        {
            [MethodImpl(Inline)]
            get => ref Storage[index];
        }

        public Symbols<K> Index
        {
            [MethodImpl(Inline)]
            get => Storage;
        }

        public ReadOnlySpan<Sym<K>> View
        {
            [MethodImpl(Inline)]
            get => Storage.View;
        }

        [MethodImpl(Inline)]
        public static implicit operator Symbols<K>(SymCache<K> src)
            => src.Index;

        static Symbols<K> Storage;
    }
}