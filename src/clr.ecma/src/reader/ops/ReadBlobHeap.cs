//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaModels;

    partial class EcmaReader
    {
        [Op]
        public EcmaHeap ReadBlobHeap()
        {
            var offset = HeapOffset(MetadataTokens.BlobHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new EcmaHeap(EcmaHeapKind.Blob, @base, HeapSize(HeapIndex.Blob));
        }
    }
}