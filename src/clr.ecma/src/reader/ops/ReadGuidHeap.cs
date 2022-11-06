//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        [Op]
        public EcmaGuidHeap ReadGuidHeap()
        {
            var offset = HeapOffset(MetadataTokens.GuidHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new EcmaGuidHeap(@base, HeapSize(HeapIndex.Guid));
        }
    }
}