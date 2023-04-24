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
            var heap = EcmaHeap.Empty;
            var size = GetHeapSize(HeapIndex.Blob);
            var offset = GetHeapOffset(HeapIndex.Blob);
            return new EcmaHeap(HeapIndex.Blob, BaseAddress + offset, size);
        }

        [Op]
        public EcmaHeap ReadGuidHeap()
        {
            var heap = EcmaHeap.Empty;
            var size = GetHeapSize(HeapIndex.Guid);
            if(size !=0)
                heap = new EcmaHeap(HeapIndex.Guid, BaseAddress + GetHeapOffset(HeapIndex.Guid), size);
            return heap;
        }

        [Op]
        public EcmaStringHeap ReadUserStringHeap()
        {
            var heap = EcmaStringHeap.Empty;
            var size = GetHeapSize(HeapIndex.UserString);
            if(size != 0)
                heap = new EcmaStringHeap(HeapIndex.UserString, BaseAddress + GetHeapOffset(HeapIndex.UserString), size);
            return heap;
        }

        [Op]
        public EcmaStringHeap ReadSystemStringHeap()
        {
            var heap = EcmaStringHeap.Empty;
            var size = GetHeapSize(HeapIndex.String);
            if(size != 0)
                heap = new EcmaStringHeap(HeapIndex.String, BaseAddress + GetHeapOffset(HeapIndex.String), size);
            return heap;
        }
    }
}