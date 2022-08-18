    //-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies a block of memory along with the base address from which it originated
    /// </summary>
    public readonly struct MemoryBlock : IComparable<MemoryBlock>
    {
        public readonly MemoryRange Origin;

        readonly BinaryCode Data;

        [MethodImpl(Inline)]
        public MemoryBlock(MemoryRange origin, BinaryCode data)
        {
            Origin = origin;
            Data = data;
        }

        [MethodImpl(Inline)]
        public MemoryBlock(MemoryAddress @base, ByteSize size, BinaryCode data)
        {
            Origin = new MemoryRange(@base,size);
            Data = data;
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

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Origin.Min;
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Origin.ByteCount;
        }

        [MethodImpl(Inline)]
        public int CompareTo(MemoryBlock src)
            => Origin.Min.CompareTo(src.Origin.Min);

        [MethodImpl(Inline)]
        public MemoryBlock<T> Keyed<T>(MemoryKey<T> key)
            where T : IEquatable<T>
                => new MemoryBlock<T>(this, key);

        public static MemoryBlock Empty
        {
            [MethodImpl(Inline)]
            get => new MemoryBlock(MemoryRange.Empty, BinaryCode.Empty);
        }
    }
}