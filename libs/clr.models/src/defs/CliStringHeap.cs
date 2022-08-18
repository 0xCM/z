//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public readonly struct CliStringHeap : ICliHeap<CliStringHeap>
    {
        public readonly MemoryAddress BaseAddress {get;}

        public readonly ByteSize Size {get;}

        public readonly CliHeapKind HeapKind {get;}

        [MethodImpl(Inline)]
        public CliStringHeap(MemoryAddress @base, ByteSize size, CliHeapKind kind)
        {
            BaseAddress = @base;
            Size = size;
            HeapKind = kind;
        }

        public unsafe ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => cover<byte>(BaseAddress, Size);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Size == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Size != 0;
        }

        public string Format()
            => string.Format(MemoryRange.define(BaseAddress, Size).Format());

        public override string ToString()
            => Format();

        public static CliStringHeap Empty
        {
            [MethodImpl(Inline)]
            get => new CliStringHeap(0,0,0);
        }
    }
}