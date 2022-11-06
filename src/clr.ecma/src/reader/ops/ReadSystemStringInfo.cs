//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public uint ReadSystemStringInfo(List<EcmaStringDetail> dst)
        {
            var reader = MD;
            int size = MD.GetHeapSize(HeapIndex.String);
            if (size == 0)
                return default;

            var handle = MetadataTokens.StringHandle(0);
            var counter=0u;
            do
            {
                dst.Add(new EcmaStringDetail(seq: counter++, size, HeapOffset(handle), String(handle)));
                handle = MD.GetNextHandle(handle);
            }
            while (!handle.IsNil);
            return counter;
        }
    }
}