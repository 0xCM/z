//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        [Op]
        public EcmaHeap ReadGuidHeap()
        {
            var offset = EcmaHeaps.offset(MD, MetadataTokens.GuidHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new EcmaHeap(EcmaHeapKind.Guid, @base, EcmaHeaps.size(MD, HeapIndex.Guid));
        }
    }
}