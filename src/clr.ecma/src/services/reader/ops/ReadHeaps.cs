//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        public EcmaHeapIndex ReadHeaps()
        {
            var dst = span<EcmaHeap>(4);
            var i=0u;
            seek(dst,i++) = ReadBlobHeap();
            seek(dst,i++) = ReadGuidHeap();
            seek(dst,i++) = ReadSystemStringHeap();
            seek(dst,i) = ReadUserStringHeap();
            return first(recover<EcmaHeap,EcmaHeapIndex>(dst));
        }

        Address32 GetHeapOffset(HeapIndex kind)
            => MD.GetHeapMetadataOffset(kind);

        ByteSize GetHeapSize(HeapIndex kind)
            => MD.GetHeapSize(kind);

        [Op]
        EcmaHeap ReadBlobHeap()
        {
            var kind = HeapIndex.Blob;
            return new EcmaHeap(kind, BaseAddress + GetHeapOffset(kind), GetHeapSize(kind));
        }

        [Op]
        EcmaHeap ReadGuidHeap()
        {
            var kind = HeapIndex.Guid;
            return new EcmaHeap(kind, BaseAddress + GetHeapOffset(kind), GetHeapSize(kind));
        }

        [Op]
        EcmaHeap ReadUserStringHeap()
        {
            var kind = HeapIndex.UserString;
            return new EcmaHeap(kind, BaseAddress + GetHeapOffset(kind), GetHeapSize(kind));
        }

        [Op]
        EcmaHeap ReadSystemStringHeap()
        {
            var kind = HeapIndex.String;
            return new EcmaHeap(kind, BaseAddress + GetHeapOffset(kind), GetHeapSize(kind));
        }
    }
}