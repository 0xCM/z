//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    [StructLayout(StructLayout, Pack=1)]
    public readonly struct EcmaHeap : IEcmaHeap<EcmaHeap>
    {        
        public readonly HeapIndex HeapKind;

        public readonly MemoryAddress BaseAddress;

        public readonly ByteSize Size;

        [MethodImpl(Inline)]
        public EcmaHeap(HeapIndex kind, MemoryAddress @base, ByteSize size)
        {
            HeapKind = kind;
            BaseAddress = @base;
            Size = size;
        }

        public unsafe ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => cover<byte>(BaseAddress, Size);
        }

        MemoryAddress IEcmaHeap.BaseAddress
            => BaseAddress;

        ByteSize IEcmaHeap.Size
            => Size;

        HeapIndex IEcmaHeap.HeapKind 
            => HeapKind;

        public string Format()
            => string.Format(MemoryRange.define(BaseAddress, Size).Format());

        public override string ToString()
            => Format();

        public static EcmaHeap Empty => default;
    }
}