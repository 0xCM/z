//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaModels;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public ByteSize HeapSize(HeapIndex index)
            => MD.GetHeapSize(index);

        [Op]
        public EcmaHeap StringHeap(EcmaStringKind kind)
            => kind switch
            {
                EcmaStringKind.User => UserStringHeap(),
                EcmaStringKind.System => SystemStringHeap(),
                _ => EcmaHeap.Empty
            };

        [Op]
        public EcmaHeap UserStringHeap()
        {
            var offset = HeapOffset(MetadataTokens.UserStringHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new EcmaHeap(EcmaHeapKind.UserString, @base, HeapSize(HeapIndex.UserString));
        }

        [Op]
        public EcmaHeap SystemStringHeap()
        {
            var offset = HeapOffset(MetadataTokens.StringHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new EcmaHeap(EcmaHeapKind.String, @base, HeapSize(HeapIndex.String));
        }
    }
}