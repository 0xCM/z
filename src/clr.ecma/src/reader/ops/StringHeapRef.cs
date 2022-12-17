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
        public EcmaHeap StringHeapRef(EcmaStringKind kind)
            => kind switch
            {
                EcmaStringKind.User => UserStringHeapRef(),
                EcmaStringKind.System => SystemStringHeapRef(),
                _ => EcmaHeap.Empty
            };

        [Op]
        public EcmaHeap UserStringHeapRef()
        {
            var offset = HeapOffset(MetadataTokens.UserStringHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new EcmaHeap(EcmaHeapKind.UserString, @base, HeapSize(HeapIndex.UserString));
        }

        [Op]
        public EcmaHeap SystemStringHeapRef()
        {
            var offset = HeapOffset(MetadataTokens.StringHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new EcmaHeap(EcmaHeapKind.String, @base, HeapSize(HeapIndex.String));
        }
    }
}