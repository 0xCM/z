//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public ByteSize HeapSize(HeapIndex index)
            => MD.GetHeapSize(index);

        [Op]
        public CliStringHeap ReadStringHeap(CliStringKind kind)
            => kind switch
            {
                CliStringKind.User => ReadUserStringHeap(),
                CliStringKind.System => ReadSystemStringHeap(),
                _ => CliStringHeap.Empty
            };

        [Op]
        public CliStringHeap ReadUserStringHeap()
        {
            var offset = HeapOffset(MetadataTokens.UserStringHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new CliStringHeap(@base, HeapSize(HeapIndex.UserString), CliHeapKind.UserString);
        }

        [Op]
        public CliStringHeap ReadSystemStringHeap()
        {
            var offset = HeapOffset(MetadataTokens.StringHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new CliStringHeap(@base, HeapSize(HeapIndex.String), CliHeapKind.String);
        }
    }
}