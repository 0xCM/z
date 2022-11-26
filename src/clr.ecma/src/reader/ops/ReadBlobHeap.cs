//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;

    partial class EcmaReader
    {
        [Op]
        public EcmaBlobHeap ReadBlobHeap()
        {
            var offset = HeapOffset(MetadataTokens.BlobHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new EcmaBlobHeap(@base, HeapSize(HeapIndex.Blob));
        }
    }
}