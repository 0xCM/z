//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies a block of memory along with the base address from which it originated
    /// </summary>
    public readonly struct MemoryBlock<T> : IComparable<MemoryBlock<T>>
        where T : IEquatable<T>
    {
        readonly MemoryBlock Source;

        public readonly MemoryKey<T> Key;

        [MethodImpl(Inline)]
        public MemoryBlock(MemoryBlock data, MemoryKey<T> key)
        {
            Source = data;
            Key = key;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Key.Hash;
        }

        public MemoryRange Origin
        {
            [MethodImpl(Inline)]
            get => Source.Origin;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsNonEmpty;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Origin.Min;
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Source.View;
        }

        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => Source.Edit;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Origin.ByteCount;
        }

        [MethodImpl(Inline)]
        public int CompareTo(MemoryBlock<T> src)
            => Origin.Min.CompareTo(src.Origin.Min);

        public override int GetHashCode()
            => Hash;
        public static MemoryBlock<T> Empty
        {
            [MethodImpl(Inline)]
            get => new MemoryBlock<T>(MemoryBlock.Empty, default);
        }

        [MethodImpl(Inline)]
        public static implicit operator MemoryBlock(MemoryBlock<T> src)
            => src.Source;
    }
}