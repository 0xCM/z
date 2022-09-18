//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a key-parametric indexed view over <see cref='MethodSlot'/> values
    /// </summary>
    public readonly struct MethodSlots<K>
        where K : unmanaged
    {
        readonly ReadOnlySeq<MethodSlot> Data;

        [MethodImpl(Inline)]
        public MethodSlots(ReadOnlySeq<MethodSlot> slots)
            => Data = slots;

        [MethodImpl(Inline)]
        public ref readonly MethodSlot Lookup(K index)
            => ref Data[uint32(index)];

        public ref readonly MethodSlot this[K index]
        {
            [MethodImpl(Inline)]
            get => ref Lookup(index);
        }

        public ref readonly MethodSlot First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref readonly MethodSlot this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }
    }
}