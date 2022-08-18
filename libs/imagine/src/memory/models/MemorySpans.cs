    //-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    /// <summary>
    /// Specifies a block of memory along with the base address from which it originated
    /// </summary>
    public readonly ref struct MemorySpan
    {
        [MethodImpl(Inline), Op]
        public static unsafe MemorySpan create(byte* pSrc, ByteSize size)
            => new MemorySpan((address(pSrc), address(pSrc) + size), cover(pSrc,size));

        public MemoryRange Origin {get;}

        readonly Span<byte> Data;

        [MethodImpl(Inline)]
        public MemorySpan(MemoryRange origin, Span<byte> data)
        {
            Origin = origin;
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
            get => !Data.IsEmpty;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Origin.Min;
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Origin.ByteCount;
        }

        public int CompareTo(MemorySpan src)
            => Origin.Min.CompareTo(src.Origin.Min);

        public static MemorySpan Empty
        {
            [MethodImpl(Inline)]
            get => new MemorySpan(MemoryRange.Empty, default);
        }
    }
}