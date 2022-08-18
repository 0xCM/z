//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CliReader
    {
        [MethodImpl(Inline), Op]
        public ByteSize HeapSize(HeapIndex index)
            => MD.GetHeapSize(index);

        [Op]
        public CliBlobHeap BlobHeap()
        {
            var offset = HeapOffset(MetadataTokens.BlobHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new CliBlobHeap(@base, HeapSize(HeapIndex.Blob));
        }

        [Op]
        public CliGuidHeap GuidHeap()
        {
            var offset = HeapOffset(MetadataTokens.GuidHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new CliGuidHeap(@base, HeapSize(HeapIndex.Guid));
        }

        [Op]
        public CliStringHeap StringHeap(CliStringKind kind)
            => kind switch
            {
                CliStringKind.User => UserStringHeap(),
                CliStringKind.System => SystemStringHeap(),
                _ => CliStringHeap.Empty
            };

        [Op]
        public CliStringHeap UserStringHeap()
        {
            var offset = HeapOffset(MetadataTokens.UserStringHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new CliStringHeap(@base, HeapSize(HeapIndex.UserString), CliHeapKind.UserString);
        }

        [Op]
        public CliStringHeap SystemStringHeap()
        {
            var offset = HeapOffset(MetadataTokens.StringHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new CliStringHeap(@base, HeapSize(HeapIndex.String), CliHeapKind.String);
        }
    }
}