//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEcmaHeap
    {
        MemoryAddress BaseAddress {get;}

        ByteSize Size {get;}

        MemoryRange Range 
            => new MemoryRange(BaseAddress, Size);

        HeapIndex HeapKind {get;}

        ReadOnlySpan<byte> Data {get;}
    }

    public interface IEcmaHeap<T> : IEcmaHeap
        where T : struct, IEcmaHeap<T>
    {

    }

    partial class XTend
    {
        public static MemoryReader GetMemoryReader(this IEcmaHeap src)
            => MemoryReader.create(src.Range);
    }
}