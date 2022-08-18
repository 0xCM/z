//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICliHeap : ITextual
    {
        MemoryAddress BaseAddress {get;}

        ByteSize Size {get;}

        CliHeapKind HeapKind {get;}

        ReadOnlySpan<byte> Data {get;}
    }

    public interface ICliHeap<T> : ICliHeap
        where T : struct, ICliHeap<T>
    {

    }
}