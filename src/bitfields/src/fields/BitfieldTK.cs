//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Bitfields;

    [StructLayout(LayoutKind.Sequential)]
    public struct Bitfield<T,K>
        where T : unmanaged
        where K : unmanaged
    {
        readonly BfDef<K> Model;

        public T State;

        [MethodImpl(Inline)]
        public Bitfield(BfDef<K> model, T state)
        {
            State = state;
            Model = model;
        }

        public ReadOnlySpan<BfSegDef<K>> SegSpecs
        {
            [MethodImpl(Inline)]
            get => Model.Segments;
        }

        [MethodImpl(Inline)]
        public ref readonly BfSegDef<K> SegSpec(byte field)
            => ref Model[field];

        [MethodImpl(Inline)]
        public T Extract(byte field)
            => api.extract(this, field);

        [MethodImpl(Inline)]
        public Bitfield<T,K> Store(byte field, T src)
        {
            api.store(src, field, ref this);
            return this;
        }

        [MethodImpl(Inline)]
        internal void Overwrite(T src)
            => State = src;
    }
}