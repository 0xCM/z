//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct EcmaStringHeap : IEcmaHeap<EcmaStringHeap>
    {
        public readonly MemoryAddress BaseAddress {get;}

        public readonly ByteSize Size {get;}

        public readonly EcmaHeapKind HeapKind {get;}

        [MethodImpl(Inline)]
        public EcmaStringHeap(MemoryAddress @base, ByteSize size, EcmaHeapKind kind)
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

        public static EcmaStringHeap Empty
        {
            [MethodImpl(Inline)]
            get => new EcmaStringHeap(0,0,0);
        }
    }
}