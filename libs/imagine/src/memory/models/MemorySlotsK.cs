//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    /// <summary>
    /// Defines a key-parametric indexed view over <see cref='MemorySeg'/> values
    /// </summary>
    public readonly struct MemorySlots<K>
        where K : unmanaged
    {
        readonly MemorySeg[] Storage;

        [MethodImpl(Inline)]
        public MemorySlots(MemorySeg[] slots)
        {
            Storage = slots;
        }

        [MethodImpl(Inline)]
        public ref MemorySeg Lookup(K index)
            => ref seek(Storage, uint32(index));

        public ref MemorySeg this[K index]
        {
            [MethodImpl(Inline)]
            get => ref Lookup(index);
        }

        public ref MemorySeg First
        {
            [MethodImpl(Inline)]
            get => ref first(Storage);
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Storage.Length;
        }
    }
}