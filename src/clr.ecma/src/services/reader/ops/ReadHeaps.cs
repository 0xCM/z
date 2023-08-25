//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static Ecma;

    partial class EcmaReader
    {
        public HeapIndex ReadHeaps()
        {
            var dst = span<EcmaHeap>(4);
            var i=0u;
            seek(dst,i++) = ReadBlobHeap();
            seek(dst,i++) = ReadGuidHeap();
            seek(dst,i++) = ReadSystemStringHeap();
            seek(dst,i) = ReadUserStringHeap();
            return first(recover<EcmaHeap,HeapIndex>(dst));
        }

        Address32 GetHeapOffset(System.Reflection.Metadata.Ecma335.HeapIndex kind)
            => MD.GetHeapMetadataOffset(kind);

        ByteSize GetHeapSize(System.Reflection.Metadata.Ecma335.HeapIndex kind)
            => MD.GetHeapSize(kind);

        [Op]
        EcmaHeap ReadBlobHeap()
        {
            var kind = System.Reflection.Metadata.Ecma335.HeapIndex.Blob;
            return new EcmaHeap(kind, BaseAddress + GetHeapOffset(kind), GetHeapSize(kind));
        }

        [Op]
        EcmaHeap ReadGuidHeap()
        {
            var kind = System.Reflection.Metadata.Ecma335.HeapIndex.Guid;
            return new EcmaHeap(kind, BaseAddress + GetHeapOffset(kind), GetHeapSize(kind));
        }

        [Op]
        EcmaHeap ReadUserStringHeap()
        {
            var kind = System.Reflection.Metadata.Ecma335.HeapIndex.UserString;
            return new EcmaHeap(kind, BaseAddress + GetHeapOffset(kind), GetHeapSize(kind));
        }

        [Op]
        EcmaHeap ReadSystemStringHeap()
        {
            var kind = System.Reflection.Metadata.Ecma335.HeapIndex.String;
            return new EcmaHeap(kind, BaseAddress + GetHeapOffset(kind), GetHeapSize(kind));
        }
    }
}