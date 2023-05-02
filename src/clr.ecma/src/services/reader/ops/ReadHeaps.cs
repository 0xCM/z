//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public Address32 GetHeapOffset(HeapIndex kind)
            => MD.GetHeapMetadataOffset(kind);

        public ByteSize GetHeapSize(HeapIndex kind)
            => MD.GetHeapSize(kind);

        [Op]
        public EcmaHeap ReadBlobHeap()
        {
            var kind = HeapIndex.Blob;
            return new EcmaHeap(kind, BaseAddress + GetHeapOffset(kind), GetHeapSize(kind));
        }

        [Op]
        public EcmaHeap ReadGuidHeap()
        {
            var kind = HeapIndex.Guid;
            return new EcmaHeap(kind, BaseAddress + GetHeapOffset(kind), GetHeapSize(kind));
        }

        [Op]
        public EcmaHeap ReadUserStringHeap()
        {
            var kind = HeapIndex.UserString;
            return new EcmaHeap(kind, BaseAddress + GetHeapOffset(kind), GetHeapSize(kind));
        }

        [Op]
        public EcmaHeap ReadSystemStringHeap()
        {
            var kind = HeapIndex.String;
            return new EcmaHeap(kind, BaseAddress + GetHeapOffset(kind), GetHeapSize(kind));
        }
    }
}