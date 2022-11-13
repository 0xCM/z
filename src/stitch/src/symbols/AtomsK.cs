//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Atomics;

    public readonly struct Atoms<K> : ITerm
    {
        readonly Index<Atom<K>> Data;

        [MethodImpl(Inline)]
        public Atoms(params Atom<K>[] terms)
        {
            Data = terms;
        }

        public Atoms<K> Concat(Atoms<K> src)
            => api.concat(this, src);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public ReadOnlySpan<Atom<K>> Members
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref Atom<K> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref Atom<K> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref Atom<K> First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public static implicit operator Atoms<K>(Atom<K>[] src)
            => new Atoms<K>(src);

        public static Atoms<K> operator+(Atoms<K> a, Atoms<K> b)
            => a.Concat(b);

        public static Atoms<K> Empty
        {
            [MethodImpl(Inline)]
            get => new Atoms<K>(sys.empty<Atom<K>>());
        }
    }
}