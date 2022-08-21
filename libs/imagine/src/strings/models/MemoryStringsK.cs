//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = MemoryStrings;

    public readonly struct MemoryStrings<K>
        where K : unmanaged
    {
        readonly MemoryStrings Data;

        [MethodImpl(Inline)]
        public MemoryStrings(in MemoryStrings data)
        {
            Data = data;
        }

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => Data.EntryCount;
        }

        public uint CharCount
        {
            [MethodImpl(Inline)]
            get => Data.CharCount;
        }

        public MemoryAddress CharBase
        {
            [MethodImpl(Inline)]
            get => Data.CharBase;
        }

        public MemoryAddress OffsetBase
        {
            [MethodImpl(Inline)]
            get => Data.OffsetBase;
        }

        [MethodImpl(Inline)]
        public int Length(uint index)
            => Data.Length(index);

        [MethodImpl(Inline)]
        public int Length(int index)
            => Data.Length(index);

        [MethodImpl(Inline)]
        public int Length(K index)
            => Data.Length(bw32(index));

        [MethodImpl(Inline)]
        public MemoryAddress Address(uint index)
            => Data.Address(index);

        [MethodImpl(Inline)]
        public MemoryAddress Address(K index)
            => Data.Address(@bw32(index));

        [MethodImpl(Inline)]
        public MemoryAddress Address(int index)
            => Data.Address(index);

        public ReadOnlySpan<char> Cells(K index)
            => Data[bw32(index)];

        public ReadOnlySpan<char> Cells(uint index)
            => Data[index];

        public ReadOnlySpan<char> Cells(int index)
            => Data[index];

        public MemoryString<K> this[K index]
        {
            [MethodImpl(Inline)]
            get => new MemoryString<K>(Address(index), Length(index));
        }

        public ReadOnlySpan<char> this[int index]
        {
            [MethodImpl(Inline)]
            get => Cells(index);
        }

        public ReadOnlySpan<char> this[uint index]
        {
            [MethodImpl(Inline)]
            get => Cells(index);
        }

        public ReadOnlySpan<uint> Offsets
        {
            [MethodImpl(Inline)]
            get => api.offsets(Data);
        }

        [MethodImpl(Inline)]
        public MemoryString<K> String(uint index)
            => new MemoryString<K>(Address(index), Length(index));

        [MethodImpl(Inline)]
        public MemoryString<K> String(int index)
            => new MemoryString<K>(Address(index), Length(index));

        [MethodImpl(Inline)]
        public MemoryString<K> String(K index)
            => new MemoryString<K>(Address(index), Length(index));

        [MethodImpl(Inline)]
        public static implicit operator MemoryStrings<K>(MemoryStrings src)
            => new MemoryStrings<K>(src);
    }
}