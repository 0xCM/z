//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public ByteSize HeapSize(HeapIndex index)
            => MD.GetHeapSize(index);

        [Op]
        public EcmaStringHeap ReadStringHeap(EcmaStringKind kind)
            => kind switch
            {
                EcmaStringKind.User => ReadUserStringHeap(),
                EcmaStringKind.System => ReadSystemStringHeap(),
                _ => EcmaStringHeap.Empty
            };

        [Op]
        public EcmaStringHeap ReadUserStringHeap()
        {
            var offset = HeapOffset(MetadataTokens.UserStringHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new EcmaStringHeap(@base, HeapSize(HeapIndex.UserString), EcmaHeapKind.UserString);
        }

        [Op]
        public EcmaStringHeap ReadSystemStringHeap()
        {
            var offset = HeapOffset(MetadataTokens.StringHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new EcmaStringHeap(@base, HeapSize(HeapIndex.String), EcmaHeapKind.String);
        }
    }
}