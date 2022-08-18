//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using api = MemorySlot;

    public struct MemorySlot<K>
        where K : unmanaged
    {
        internal K Index;

        [MethodImpl(Inline)]
        public MemorySlot(K value)
            => Index = value;

        [MethodImpl(Inline)]
        public MemorySlot<K> Advance()
            => api.advance(ref this);

        [MethodImpl(Inline)]
        public MemorySlot<K> Retreat()
            => api.retreat(ref this);

        [MethodImpl(Inline)]
        public static MemorySlot<K> operator++(MemorySlot<K> src)
            => src.Advance();

        [MethodImpl(Inline)]
        public static MemorySlot<K> operator--(MemorySlot<K> src)
            => src.Retreat();

        [MethodImpl(Inline)]
        public static implicit operator K(MemorySlot<K> src)
            => src.Index;

        [MethodImpl(Inline)]
        public static implicit operator MemorySlot<K>(K src)
            => new MemorySlot<K>(src);
    }
}