//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEcmaHeap : ITextual
    {
        MemoryAddress BaseAddress {get;}

        ByteSize Size {get;}

        EcmaHeapKind HeapKind {get;}

        ReadOnlySpan<byte> Data {get;}
    }

    public interface IEcmaHeap<T> : IEcmaHeap
        where T : struct, IEcmaHeap<T>
    {

    }
}