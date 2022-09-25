//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        [Op]
        public CliGuidHeap ReadGuidHeap()
        {
            var offset = HeapOffset(MetadataTokens.GuidHandle(0));
            var @base = Segment.BaseAddress + offset;
            return new CliGuidHeap(@base, HeapSize(HeapIndex.Guid));
        }
    }
}