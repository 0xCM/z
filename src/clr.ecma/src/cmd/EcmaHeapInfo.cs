//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class EcmaHeapInfo
    {
        [Render(12)]
        public EcmaHeapKind HeapKind;

        [Render(16)]
        public MemoryAddress BaseAddress;

        [Render(16)]
        public ByteSize Size;

        [Render(1)]
        public FilePath Source;
    }
}