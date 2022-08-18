//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    [StructLayout(StructLayout, Pack=1)]
    public readonly struct CliBlobHeap : ICliHeap<CliBlobHeap>
    {
        public readonly MemoryAddress BaseAddress;

        public readonly ByteSize Size;

        [MethodImpl(Inline)]
        public CliBlobHeap(MemoryAddress @base, ByteSize size)
        {
            BaseAddress = @base;
            Size = size;
        }

        public CliHeapKind HeapKind
        {
            [MethodImpl(Inline)]
            get => CliHeapKind.Blob;
        }

        public unsafe ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => cover<byte>(BaseAddress, Size);
        }

        MemoryAddress ICliHeap.BaseAddress
            => BaseAddress;

        ByteSize ICliHeap.Size
            => Size;

        public string Format()
            => string.Format(MemoryRange.define(BaseAddress, Size).Format());

        public override string ToString()
            => Format();
    }
}